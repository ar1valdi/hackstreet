from get_noise_request import get_noise_by_coords
import pandas as pd


# ul warszawska
#get_noise_by_coords(54.336183,18.595688)

# in km
one_lat = 65
one_lon = 111.1

iterations_x = 60
iterations_y = 40

distance_x = 30
distance_y = 20

results = []

for i in range(iterations_y):
    for j in range(iterations_x):
        offset_x = j/iterations_x *distance_x/one_lat
        offset_y = i/iterations_y * distance_y/one_lon
        print(f"{(i*iterations_x+j)/(iterations_x*iterations_y)*100}% offset_x:{j/iterations_x *distance_x} offset_y:{i/iterations_y * distance_y}")
        lat = 54.446748 - offset_y
        lon = 18.353185 + offset_x
        result = get_noise_by_coords(lat,lon)
        
        try:
            min_db = result['MINVAL']
            max_db = result['MAXVAL']
            results.append([lat,lon,min_db,max_db])
        except:
            continue
        

df = pd.DataFrame(results,columns=['lat','lon','min_db','max_db'])
df.to_csv("out_noise.csv",sep=';')