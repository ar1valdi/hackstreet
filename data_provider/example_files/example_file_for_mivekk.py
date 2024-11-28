import pandas as pd

df = pd.read_csv("example_files/out_noise.csv",sep=";")

print(df)

results_list = []
for index, row in df.iterrows():
    one_row = dict()
    one_row['lat'] = float(row['lat'])
    one_row['lon'] = float(row['lon'])
    one_row['min_db'] = float(row['min_db'])
    one_row['max_db'] = float(row['max_db'])
    one_row['mean_db'] = float(row['min_db']+row['max_db'])/2
    results_list.append(one_row)
    
print(results_list)

text_file = open("Output.txt", "w")

text_file.write(str(results_list))

text_file.close()