using HackstreeetServer.src.Models.Measures;
using HackstreeetServer.src.Repositories;
using System.Xml.Serialization;

namespace HackstreeetServer.src.Services
{
    public class EcoGraderService
    {
        IMeasureRepository _measureRepository;

        public EcoGraderService(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public async Task<float> FilterGrade(float latitude, float longitude, string categoryFilter)
        {
            switch (categoryFilter)
            {
                case "powietrze":
                    {
                        float meanNO2Value = await GradePointOneFilter(latitude, longitude, "dwutlenek azotu");
                        float NO2Grade;

                        if (meanNO2Value < 40)
                        {
                            NO2Grade = 100;
                        }else if (meanNO2Value < 100)
                        {
                            NO2Grade = 80;
                        }
                        else if (meanNO2Value < 150)
                        {
                            NO2Grade = 60;
                        }
                        else if (meanNO2Value < 230)
                        {
                            NO2Grade = 40;
                        }
                        else if (meanNO2Value < 400)
                        {
                            NO2Grade = 20;
                        }
                        else
                        {
                            NO2Grade = 0;
                        }

                        float meanBenzinValue = await GradePointOneFilter(latitude, longitude, "benzen");
                        float BenzinGrade;

                        if (meanBenzinValue < 40)
                        {
                            BenzinGrade = 100;
                        }
                        else if (meanBenzinValue < 100)
                        {
                            BenzinGrade = 80;
                        }
                        else if (meanBenzinValue < 150)
                        {
                            BenzinGrade = 60;
                        }
                        else if (meanBenzinValue < 230)
                        {
                            BenzinGrade = 40;
                        }
                        else if (meanBenzinValue < 400)
                        {
                            BenzinGrade = 20;
                        }
                        else
                        {
                            BenzinGrade = 0;
                        }
                        float meanSO2Value = await GradePointOneFilter(latitude, longitude, "dwutlenek siarki");
                        float SO2Grade;

                        if (meanSO2Value < 50)
                        {
                            SO2Grade = 100;
                        }
                        else if (meanSO2Value < 100)
                        {
                            SO2Grade = 80;
                        }
                        else if (meanSO2Value < 200)
                        {
                            SO2Grade = 60;
                        }
                        else if (meanSO2Value < 350)
                        {
                            SO2Grade = 40;
                        }
                        else if (meanSO2Value < 500)
                        {
                            SO2Grade = 20;
                        }
                        else
                        {
                            SO2Grade = 0;
                        }
                        float meanO3Value = await GradePointOneFilter(latitude, longitude, "ozon");
                        float O3Grade;

                        if (meanO3Value < 70)
                        {
                            O3Grade = 100;
                        }
                        else if (meanO3Value < 120)
                        {
                            O3Grade = 80;
                        }
                        else if (meanO3Value < 150)
                        {
                            O3Grade = 60;
                        }
                        else if (meanO3Value < 180)
                        {
                            O3Grade = 40;
                        }
                        else if (meanO3Value < 240)
                        {
                            O3Grade = 20;
                        }
                        else
                        {
                            O3Grade = 0;
                        }
                        float meanPM10Value = await GradePointOneFilter(latitude, longitude, "pył zawieszony PM10");
                        float PM10Grade;

                        if (meanPM10Value < 20)
                        {
                            PM10Grade = 100;
                        }
                        else if (meanPM10Value < 50)
                        {
                            PM10Grade = 80;
                        }
                        else if (meanPM10Value < 80)
                        {
                            PM10Grade = 60;
                        }
                        else if (meanPM10Value < 110)
                        {
                            PM10Grade = 40;
                        }
                        else if (meanPM10Value < 150)
                        {
                            PM10Grade = 20;
                        }
                        else
                        {
                            PM10Grade = 0;
                        }
                        float meanPM25Value = await GradePointOneFilter(latitude, longitude, "pył zawieszony PM2.5");
                        float PM25Grade;

                        if (meanPM25Value < 13)
                        {
                            PM25Grade = 100;
                        }
                        else if (meanPM25Value < 35)
                        {
                            PM25Grade = 80;
                        }
                        else if (meanPM25Value < 55)
                        {
                            PM25Grade = 60;
                        }
                        else if (meanPM25Value < 75)
                        {
                            PM25Grade = 40;
                        }
                        else if (meanPM25Value < 110)
                        {
                            PM25Grade = 20;
                        }
                        else
                        {
                            PM25Grade = 0;
                        }
                        float meanCOValue = await GradePointOneFilter(latitude, longitude, "tlenek węgla");
                        float COGrade;

                        if (meanCOValue < 2000)
                        {
                            COGrade = 100;
                        }
                        else if (meanCOValue < 10000)
                        {
                            COGrade = 50;
                        }
                        else
                        {
                            COGrade = 0;
                        }


                        float result = (COGrade + PM25Grade + PM10Grade + O3Grade + NO2Grade + SO2Grade) / 6;

                        return result;

                        break;
                    }
                case "woda":
                    {
                        float meanHardnessValue = await GradePointOneFilter(latitude, longitude, "Twardość - mg/l");
                        float HardnessGrade;

                        if (meanHardnessValue < 60)
                        {
                            HardnessGrade = 100;
                        }
                        else if (meanHardnessValue < 100)
                        {
                            HardnessGrade = 80;
                        }
                        else if (meanHardnessValue < 200)
                        {
                            HardnessGrade = 60;
                        }
                        else if (meanHardnessValue < 400)
                        {
                            HardnessGrade = 40;
                        }
                        else if (meanHardnessValue < 600)
                        {
                            HardnessGrade = 20;
                        }
                        else
                        {
                            HardnessGrade = 0;
                        }


                        float meanPHValue = await GradePointOneFilter(latitude, longitude, "pH");
                        float PHGrade;

                        if (Math.Abs(meanPHValue-8) < 0.5)
                        {
                            PHGrade = 100;
                        }
                        else if (Math.Abs(meanPHValue - 8) < 0.7)
                        {
                            PHGrade = 80;
                        }
                        else if (Math.Abs(meanPHValue - 8) < 0.9)
                        {
                            PHGrade = 60;
                        }
                        else if (Math.Abs(meanPHValue - 8) < 1.2)
                        {
                            PHGrade = 40;
                        }
                        else if (Math.Abs(meanPHValue - 8) < 1.5)
                        {
                            PHGrade = 20;
                        }
                        else
                        {
                            PHGrade = 0;
                        }


                        float meanSodiumValue = await GradePointOneFilter(latitude, longitude, "Sód");
                        float SodiumGrade;

                        if (Math.Abs(meanSodiumValue - 150) < 20)
                        {
                            SodiumGrade = 100;
                        }
                        else if (Math.Abs(meanSodiumValue - 150) < 50)
                        {
                            SodiumGrade = 50;
                        }
                        else
                        {
                            SodiumGrade = 0;
                        }



                        float meanChloriumValue = await GradePointOneFilter(latitude, longitude, "Chlorki");
                        float ChloriumGrade;

                        if (meanChloriumValue < 250)
                        {
                            ChloriumGrade = 100;
                        }
                        else
                        {
                            ChloriumGrade = 0;
                        }


                        float meanFluoriumValue = await GradePointOneFilter(latitude, longitude, "Fluorki");
                        float FluoriumGrade;

                        if (meanFluoriumValue < 1.5)
                        {
                            FluoriumGrade = 100;
                        }
                        else
                        {
                            FluoriumGrade = 0;
                        }


                        float meanSulfurValue = await GradePointOneFilter(latitude, longitude, "Siarczany");
                        float SulfurGrade;

                        if (meanSulfurValue < 250)
                        {
                            SulfurGrade = 100;
                        }
                        else
                        {
                            SulfurGrade = 0;
                        }

                        float meanHFValue = await GradePointOneFilter(latitude, longitude, "Wodorowęglany");
                        float HFGrade;

                        if (meanHFValue < 600)
                        {
                            HFGrade = 100;
                        }
                        else if (meanHFValue < 1000)
                        {
                            HFGrade = 20;
                        }
                        else
                        {
                            HFGrade = 0;
                        }

                        float meanClValue = await GradePointOneFilter(latitude, longitude, "Chlor wolny");
                        float ClGrade;

                        if (meanClValue < 0.3)
                        {
                            ClGrade = 100;
                        }
                        else
                        {
                            ClGrade = 0;
                        }

                        float result = (HardnessGrade + PHGrade + SodiumGrade + ChloriumGrade + FluoriumGrade + SulfurGrade + HFGrade+ClGrade) / 8;

                        return result;
                    }
                case "hałas":
                    {
                        break;
                    }
                case "światło":
                    {
                        break;
                    }
                case "piece":
                    {
                        break;
                    }
                default: {
                        return -1;
                    }
            }
            



            return resultValue;
        }

        public async Task<float> GradePointOneFilter(float latitude, float longitude, string filter)
        {
            var closestStations = await GetClosestStationsWithFilter(filter, latitude, longitude, 4);

            float fullDistance = 0;
            foreach (var station in closestStations)
            {
                fullDistance += GetDistance(station.Latitude,station.Longitude,latitude,longitude);
            }
            float resultValue=0;
            foreach (var station in closestStations)
            {
                resultValue += (float)station.Measures.FirstOrDefault().Value * GetDistance(station.Latitude, station.Longitude, latitude, longitude)/fullDistance;
            }

            return resultValue;
        }


        private async Task<List<Station>> GetClosestStationsWithFilter(string filter, float latitude, float longitude,int maxClosestPoints)
        {
            var stations = await _measureRepository.GetStationBySensing(filter);
            List<Station> closestStations = new List<Station>(maxClosestPoints);
            List<float> closestDistances = new List<float>(maxClosestPoints);

            foreach (var station in stations)
            {
                var distance = GetDistance(latitude, longitude, station.Latitude, station.Longitude);

                if (closestStations.Count < maxClosestPoints)
                {
                    closestStations.Add(station);
                    closestDistances.Add(distance);
                }
                else
                {
                    for (int i = 0; i < closestDistances.Count; i++)
                    {
                        if (distance < closestDistances[i])
                        {
                            closestStations[i] = station;
                            closestDistances[i] = distance;
                        }
                    }
                }
            }

            return closestStations;
        }

        private float GetDistance(float latA, float lonA, float latB, float lonB)
        {
            return (float)Math.Sqrt((latB - latA)*(latB - latA) + (lonB - lonA)*(lonB - lonA));
        }
    }
}
