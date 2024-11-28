import pandas as pd

df = pd.read_csv("out_light.csv",sep=";")

print(df)

results_list = []
for index, row in df.iterrows():
    one_row = dict()
    one_row['lat'] = float(row['lat'])
    one_row['lon'] = float(row['lon'])
    one_row['light'] = float(row['light'])
    results_list.append(one_row)
    
print(results_list)

text_file = open("Output_lights.txt", "w")

text_file.write(str(results_list))

text_file.close()