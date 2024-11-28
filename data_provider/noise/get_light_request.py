import requests
import json



def get_light_by_coords(lat,lon):
    
    try:
        str_link = f'https://geogdansk.pl/server/rest/services/WSrod/Halas_Drogi_LDWN/MapServer/0/query?f=json&geometry=%7B%22xmin%22%3A{x}%2C%22ymin%22%3A{y}%2C%22xmax%22%3A{x}%2C%22ymax%22%3A{y}%7D&outFields=MAXVAL%2CMINVAL&spatialRel=esriSpatialRelIntersects&where=1%3D1&geometryType=esriGeometryEnvelope&inSR=2177&outSR=2177'
        str_link = f'https://www.lightpollutionmap.info/QueryRaster/?qk=MTczMjgxNjYzODc2ODtpc3Vja2RpY2tzOik=&ql=wa_2015&qt=point&qd={lat},{lon}'
        #print(str_link)
        result = requests.get(str_link)
        res_attrs = {}
        res = result.text().split(',')
        res_attrs['light'] = res[0]
        res_attrs['height'] = res[1]
        res_attrs['lat'] = lat
        res_attrs['lon'] = lon
        
    except:
        res_attrs= {}
        res_attrs['light'] = -1
        res_attrs['height'] = -1
        res_attrs['lat'] = lat
        res_attrs['lon'] = lon
        res_attrs['x'] = x
        res_attrs['y'] = y
    
    print(f"lat:{lat} lon:{lon} attrs: {res_attrs}")
    return res_attrs