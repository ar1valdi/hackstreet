from get_noise_request import get_noise_by_coords
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
        offset_x = j/iterations_x *distance_x/one_lat
        offset_y = i/iterations_y * distance_y/one_lon
        print(f"{(i*iterations_x+j)/(iterations_x*iterations_y)*100}")
        lat = 54.446748 - offset_y
        lon = 18.353185 + offset_x
        lats.append(lat)
        longs.append(lon)
        

data = pd.DataFrame()

data['lat'] = lats
data['lon'] = longs

results = pd.DataFrame()

def get_noise_for_row(row):
    return get_noise_by_coords(row['lat'], row['lon'])

with ThreadPoolExecutor(max_workers=10) as executor:
    future_to_index = {executor.submit(get_noise_for_row, row): i for i, row in data.iterrows()}
    i = 0
    for future in as_completed(future_to_index):
        
        print('iterator ',i)
        try:
            result = future.result()
            lat=result['lat']
            lon=result['lon']
            x=result['x']
            y=result['y']
            min_db = result['MINVAL']
            max_db = result['MAXVAL']
            results.append([lat,lon,min_db,max_db])
        except Exception as e:
            print(f"Error getting data: {e}")
        i += 1