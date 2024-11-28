from get_light_request import get_light_by_coords
import pandas as pd
import numpy as np
from concurrent.futures import ThreadPoolExecutor, as_completed



one_lat = 65
one_lon = 111.1

iterations_x = 60
iterations_y = 40

distance_x = 30
distance_y = 20

results = []

lats = []
longs = []
for i in range(iterations_y):
    for j in range(iterations_x):
        #if(1669<(i*iterations_x+j)):
        offset_x = j/iterations_x *distance_x/one_lat
        offset_y = i/iterations_y * distance_y/one_lon
        print(f"{(i*iterations_x+j)/(iterations_x*iterations_y)*100}")
        lon = 54.446748 - offset_y
        lat = 18.353185 + offset_x
        lats.append(lat)
        longs.append(lon)
        

data = pd.DataFrame()

data['lat'] = lats
data['lon'] = longs

results = []

id = 462430+1669

def get_noise_for_row(row):
    return get_light_by_coords(row['lat'], row['lon'])

with ThreadPoolExecutor(max_workers=100) as executor:
    future_to_index = {executor.submit(get_noise_for_row, row): i for i, row in data.iterrows()}
    i = 0
    for future in as_completed(future_to_index):
        print('iterator ',i)
        result = future.result()
        lat=result['lat']
        lon=result['lon']
        try:
            light = result['light']
            height = result['height']
            results.append([id,lat,lon,light,height,4])
        except Exception as e:
            print(f"Error getting data: {e}")
            #results.append([id,lat,lon,x,y,None,None,2])
        i += 1
        id+=1
        
        
df = pd.DataFrame(results,columns=['id','lat','lon','light','height','station_type'])
df.to_csv("out_light.csv",sep=';')