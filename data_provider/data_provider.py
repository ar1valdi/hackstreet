import pandas as pd
import requests
from io import StringIO
import numpy as np
import csv

def get_measures_names(stations):

    names = set()
    for station in stations:
        station_id = station.id
        link = station.sensors_api_link

        response_station = requests.get(link)
        json_data = StringIO(response_station.text)
        station_sensors = pd.read_json(json_data)

        for sensor in station_sensors.values:
            names.add(sensor[2]['paramCode'])
    
    return list(names)


class Station:
    def __init__(self, link, id, lat, long):
        self.sensors_api_link = link
        self.id = id
        self.latitude = lat
        self.longitude = long
        self.dict = {
            "id": self.id,
            "latitude": self.latitude,
            "longitude": self.longitude,
            "station_type": 1
        }


    def get_sensors(self):
        response_station = requests.get(self.sensors_api_link)
        json_data = StringIO(response_station.text)
        data = pd.read_json(json_data)

        sensors = []
        
        for sensor in data.values:
            sensor_id = sensor[0]
            sensor_code = sensor[2]['paramCode']
            sensor_sensing = sensor[2]['paramName']
            # self.dict[sensor_code] = sensor_id

            sensors.append(Sensor(id=sensor_id, station_id=self.id, station=self, code=sensor_code, sensing=sensor_sensing))

            # sensor_measure_link = "https://api.gios.gov.pl/pjp-api/rest/data/getData/" + str(sensor[0])
            # response_sensor = requests.get(sensor_measure_link)
            # json_data = StringIO(response_sensor.text)
            # sensor_measures = pd.read_json(json_data)

            # for measure in sensor_measures.values:
            #     measure_key = measure[0]
            #     measure_date = measure[1]['date']
            #     measure_val = measure[1]['value']

            #     self.dict['date'] = measure_date
            #     self.dict['value'] = measure_val
        return sensors


class Sensor:
    def __init__(self, id, station, station_id, code, sensing):
        self.id = id
        self.measure_link = "https://api.gios.gov.pl/pjp-api/rest/data/getData/" + str(self.id)
        self.station = station
        self.sensing = sensing
        self.dict = {
            "id": self.id,
            "station_id": station_id,
            "keycode": code,
            "sensing": sensing
        }


class Measure:
    def __init__(self, station_id, date, value, sensing):
        self.dict = {
            "data": date,
            "station_id": station_id,
            "value": value,
            "min_value": None,
            "max_value": None,
            "sensing": sensing,
            "category": 'powietrze'
        }


class DataProvider:
    def __init__(self):
        self.stations_link = "https://api.gios.gov.pl/pjp-api/rest/station/findAll"
        self.stations = self.get_stations()
        self.sensors = self.get_sensors()
        self.measures = self.get_measures()
        pass

    def get_stations(self, city_names=["Gdańsk", "Sopot"]):
        response_stations = requests.get(self.stations_link)
        json_data = StringIO(response_stations.text)
        data = pd.read_json(json_data)

        stations = []
        for station in data.values:
            for city_name in city_names:
                if station[1].startswith(city_name):
                    id = station[0]
                    lat = station[2]
                    lon = station[3]
                    sensors_link = "https://api.gios.gov.pl/pjp-api/rest/station/sensors/" + str(id)
                    stations.append(Station(link=sensors_link, id=id, lat=lat, long=lon))

        if len(stations) == 1:
            return stations[0]
        return stations
    
    def get_sensors(self):
        all_sensors = []

        for station in self.stations:
            all_sensors.extend(station.get_sensors())
        
        return all_sensors

    def get_measures(self):
        measures = []

        for sensor in self.sensors:
            link = "https://api.gios.gov.pl/pjp-api/rest/data/getData/" + str(sensor.id)
            response_sensor = requests.get(link)
            json_data = StringIO(response_sensor.text)
            sensor_measures = pd.read_json(json_data)

            for measure in sensor_measures.values:
                measure_date = measure[1]['date']
                measure_val = measure[1]['value']

                if measure_val is not None:
                    measures.append(Measure(station_id=sensor.station.id, date=measure_date, value=measure_val, sensing=sensor.sensing))
                    break
                
        return measures

    def save_to_csv(self):
        stations_file = open('Stations.csv', 'w')
        w = csv.DictWriter(stations_file, self.stations[0].dict.keys())
        for station in self.stations:
            w.writerow(station.dict)
        stations_file.close()

        # sensors_file = open('Sensors.csv', 'w')
        # w = csv.DictWriter(sensors_file, self.sensors[0].dict.keys())
        # for sensor in self.sensors:
        #     w.writerow(sensor.dict)
        # sensors_file.close()

        measures_file = open('Measures.csv', 'w')
        w = csv.DictWriter(measures_file, self.measures[0].dict.keys())
        for measure in self.measures:
            w.writerow(measure.dict)
        measures_file.close()



if __name__ == "__main__":
    provider = DataProvider()

    provider.save_to_csv()
    # stations = provider.get_stations()
    a = 1
    # measures_names = get_measures_names(stations=stations)


    # for station in stations:
    #     dict = {
    #         "station_id": station.id,
    #         "latitude": station.latitude,
    #         "longitude": station.longitude,
    #         "station_type": "Air quality"
    #     }

    #     # for measure in measures_names:
    #     #     dict[measure] = None
        
    #     station.dict = dict
    #     station.get_station_measures()


    #     pass