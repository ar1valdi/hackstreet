import pandas as pd
import datetime
import random

light_data = pd.read_csv('out_noise.csv',sep=";")



light_data = light_data.sample(n=1000)



df_outlughts = pd.DataFrame(columns=['date','station_id','value','min_value','max_value','sensing','category'],)

df_outlughts['date'] = ['2024-11-26 00:00:00' for i in range(light_data.shape[0])]
df_outlughts['station_id'] = light_data['id']
df_outlughts['value'] = (light_data['min_db']+light_data['max_db'])/2
df_outlughts['min_value'] = light_data['min_db']
df_outlughts['max_value'] = light_data['max_db']
df_outlughts['sensing'] = ['poziom hałasu' for i in range(light_data.shape[0])]
df_outlughts['category'] = ['hałas' for i in range(light_data.shape[0])]

df_outlughts.to_csv('noise_measures.csv',sep=";",index=False,header=False)

df_outstations = pd.DataFrame(columns=['id','latitude','longitude','station_type'])

df_outstations['id'] = light_data['id']
df_outstations['latitude'] = light_data['lon']
df_outstations['longitude'] = light_data['lat']
df_outstations['station_type'] = light_data['station_type']

df_outstations.to_csv('stations_noise.csv',sep=";",index=False,header=False)





