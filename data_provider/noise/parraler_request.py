from get_noise_request import get_noise_by_coords
import pandas as pd
import numpy as np
from concurrent.futures import ThreadPoolExecutor, as_completed



one_lat = 65
one_lon = 111.1

iterations_x = 300
iterations_y = 200

distance_x = 30
distance_y = 20

results = []

lats = []
longs = []
for i in range(iterations_y):
    for j in range(iterations_x):
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

id = 16243

def get_noise_for_row(row):
    return get_noise_by_coords(row['lat'], row['lon'])

with ThreadPoolExecutor(max_workers=50) as executor:
    future_to_index = {executor.submit(get_noise_for_row, row): i for i, row in data.iterrows()}
    i = 0
    for future in as_completed(future_to_index):
        print('iterator ',i)
        result = future.result()
        lat=result['lat']
        lon=result['lon']
        x=result['x']
        y=result['y']
        try:
            min_db = result['MINVAL']
            max_db = result['MAXVAL']
            results.append([id,lat,lon,x,y,min_db,max_db,2])
        except Exception as e:
            print(f"Error getting data: {e}")
            #results.append([id,lat,lon,x,y,None,None,2])
        if(i % 10000 == 0 or i  == 59900):
            df = pd.DataFrame(results,columns=['id','lat','lon','x','y','min_db','max_db','station_type'])
            df.to_csv("out_noise.csv",sep=';')
        i += 1
        id+=1
        
        
df = pd.DataFrame(results,columns=['id','lat','lon','x','y','min_db','max_db','station_type'])
df.to_csv("out_noise.csv",sep=';')