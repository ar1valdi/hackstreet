import requests
import json

def conv_lat_to_x(lat):
    res = (lat-18.591573)*64546.27909872957+6538378.755415827
    return res
def conv_lon_to_y(lon):
    res = (lon-54.430374)*111259.56564514196+6033512.913664646
    return res
    
    

def conv_y_to_lat(y):
    res = (y-6538378.755415827)/64546.27909872957 + 18.591573
    return res
def conv_x_to_lon(x):
    res = (x-6033512.913664646)/111259.56564514196 + 54.430374
    return res


def get_noise_by_coords(lat,lon):
    x = conv_lat_to_x(lat)
    y= conv_lon_to_y(lon)
    
    try:
        str_link = f'https://geogdansk.pl/server/rest/services/WSrod/Halas_Drogi_LDWN/MapServer/0/query?f=json&geometry=%7B%22xmin%22%3A{x}%2C%22ymin%22%3A{y}%2C%22xmax%22%3A{x}%2C%22ymax%22%3A{y}%7D&outFields=MAXVAL%2CMINVAL&spatialRel=esriSpatialRelIntersects&where=1%3D1&geometryType=esriGeometryEnvelope&inSR=2177&outSR=2177'
        #print(str_link)
        result = requests.get(str_link)
        res_attrs = result.json()['features'][0]['attributes']
        res_attrs['lat'] = lat
        res_attrs['lon'] = lon
        res_attrs['x'] = x
        res_attrs['y'] = y
        
    except:
        res_attrs= {}
        res_attrs['lat'] = lat
        res_attrs['lon'] = lon
        res_attrs['x'] = x
        res_attrs['y'] = y
    
    print(f"lat:{lat} lon:{lon} x:{x} y:{y} attrs: {res_attrs}")
    return res_attrs