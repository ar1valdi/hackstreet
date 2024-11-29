import pandas as pd
import datetime

light_data = pd.read_csv('out_noise.csv',sep=";")

#light_data = light_data.sample(n=1000)



df_outlughts = pd.DataFrame(columns=['date','station_id','value'])

df_outlughts['date'] = ['2024-11-26 00:00:00' for i in range(light_data.shape[0])]
df_outlughts['station_id'] = light_data['id']
df_outlughts['value'] = light_data['light']
df_outlughts['sensing'] = ['poziom światła' for i in range(light_data.shape[0])]
df_outlughts['category'] = ['światło' for i in range(light_data.shape[0])]

df_outlughts.to_csv('lights.csv',sep=";",index=False,header=False)

df_outstations = pd.DataFrame(columns=['id','latitude','longitude','station_type'])

df_outstations['id'] = light_data['id']
df_outstations['latitude'] = light_data['lon']
df_outstations['longitude'] = light_data['lat']
df_outstations['station_type'] = light_data['station_type']

df_outstations.to_csv('stations_lights.csv',sep=";",index=False,header=False)





