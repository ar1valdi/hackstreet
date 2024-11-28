import pandas as pd
import requests
from io import StringIO
import numpy as np

class StationMeasure:
    def __init__(self):
        self.station_id = None
        self.latitude = None
        self.longitude = None
        self.no2 = None


        pass


class DataProvider:
    def __init__(self):
        self.stations_link = "https://api.gios.gov.pl/pjp-api/rest/station/findAll"
        pass

    def get_stations(self, city_name="Gdańsk"):
        response_stations = requests.get(self.stations_link)
        json_data = StringIO(response_stations.text)
        data = pd.read_json(json_data)
        stations = []

        for station in data.values:
            if station[1].startswith(city_name):
                stations.append(station)

        return stations


if __name__ == "__main__":
    provider = DataProvider()
    stations = provider.get_stations()
    stations.append(provider.get_stations(city_name="Sopot"))

    for station in stations:
        a = 1
        link = "https://api.gios.gov.pl/pjp-api/rest/station/sensors/" + station[0]

        
        pass