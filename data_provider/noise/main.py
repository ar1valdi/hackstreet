import requests
import json

# jelitkowo
j_lat = 54.430374
j_lon = 18.591573

j_xmin =6538378.59666551
j_xmax = 6538378.914166144
j_ymin = 6033512.754914332
j_ymax = 6033513.07241496

j_x = (j_xmin+j_xmax)/2
j_y = (j_ymin+j_ymax)/2

#print(f"j_x:{j_x}")
#print(f"j_y:{j_y}")

# warszawska
w_lat = 54.336183
w_lon = 18.595688

w_xmin =6538746.734893293
w_xmax = 6538747.052393927
w_ymin = 6023033.105166648
w_ymax = 6023033.422667282

w_x = (w_xmin+w_xmax)/2
w_y = (w_ymin+w_ymax)/2

#print(f"w_x:{w_x}")
#print(f"w_y:{w_y}")

# rondo przy lotnisku
r_lat = 54.383479
r_lon = 18.468725

r_xmin =6530449.215370789
r_xmax = 6530449.532871423
r_ymin = 6028234.623866337
r_ymax = 6028234.9413669715

r_x = (r_xmin+r_xmax)/2
r_y = (r_ymin+r_ymax)/2


# jelitkowo - warszawska
d_lat = w_lat - j_lat
d_lon = w_lon - j_lon
d_x = w_x - j_x
d_y = w_y - j_y

#print(f"y/lat:{d_y/d_lat} x/lon:{d_x/d_lon}")


# jelitkowo - rondoa
d_lat = r_lat - j_lat
d_lon = r_lon - j_lon
d_x = r_x - j_x
d_y = r_y - j_x

#print(f"y/lat:{d_y/d_lat} x/lon:{d_x/d_lon}")
# rondo - warszawskaa
d_lat = w_lat - r_lat
d_lon = w_lon - r_lon
d_x = w_x - r_x
d_y = w_y - r_x

#print(f"y/lat:{d_y/d_lat} x/lon:{d_x/d_lon}")


def conv_lat_to_y(lat):
    res = (lat-54.430374)*111259.56564514196+6033512.913664646
    return res
def conv_lon_to_x(lon):
    res = (lon-18.591573)*64546.27909872957+6538378.755415827
    return res
    
    

def conv_y_to_lat(y):
    res = (y-6033512.913664646)/111259.56564514196 + 54.430374
    return res
def conv_x_to_lon(x):
    res = (x-6538378.755415827)/64546.27909872957 + 18.591573
    return res

#print(f"56 lat: {conv_lat_to_y(56)}")

def get_noise_by_coords(lat,lon):
    y = conv_lat_to_y(lat)
    x= conv_lon_to_x(lon)
    
    str_link = f'https://geogdansk.pl/server/rest/services/WSrod/Halas_Drogi_LDWN/MapServer/0/query?f=json&geometry=%7B%22xmin%22%3A{x}%2C%22ymin%22%3A{y}%2C%22xmax%22%3A{x}%2C%22ymax%22%3A{y}%7D&outFields=MAXVAL%2CMINVAL&spatialRel=esriSpatialRelIntersects&where=1%3D1&geometryType=esriGeometryEnvelope&inSR=2177&outSR=2177'
    #print(str_link)
    result = requests.get(str_link)
    res_attrs = result.json()['features'][0]['attributes']
    
    print(f"lat:{lat} lon:{lon} x:{x} y:{y} attrs: {res_attrs}")
    return res_attrs

get_noise_by_coords(54.336183,18.595688)