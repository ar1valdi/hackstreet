
class FurnanceData:
    def __init__(self, ds_name, value):
        self.district_name = ds_name
        self.value = value


if __name__ == "__main__":
    f = open("PRZEDKONICZYN.txt", "r")
    file_text = f.read().upper()
    f2 = open("PRZEDKONICZYN2.txt", "w")
    f2.write(file_text)
    f.close()
    f2.close()



