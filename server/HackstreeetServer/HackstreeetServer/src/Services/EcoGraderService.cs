using HackstreeetServer.src.Models;
using HackstreeetServer.src.Models.Measures;
using HackstreeetServer.src.Repositories;

namespace HackstreeetServer.src.Services
{
    public class EcoGraderService : IEcoGraderService
    {
        IMeasureRepository _measureRepository;

        public EcoGraderService(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public async Task<float> FilterGrade(float latitude, float longitude, string categoryFilter, Station[] measures)
        {
            switch (categoryFilter)
            {
                case "powietrze":
                    {
                        var airOnly = measures.Where(m => m.Measures.Where(m => m.Category == "powietrze").Any()).ToArray();
                        float meanNO2Value = GradePointOneFilter(latitude, longitude, "dwutlenek azotu", airOnly);
                        float NO2Grade;


                        if (meanNO2Value < 20)
                        {
                            NO2Grade = 100;
                        } else if(meanNO2Value > 400) {
                            NO2Grade = 0;
                        }
                        else {
                            NO2Grade = (400 - meanNO2Value) / 380 * 100;
                        }
                        
                        float meanSO2Value = GradePointOneFilter(latitude, longitude, "dwutlenek siarki", airOnly);
                        float SO2Grade;

                        if (meanSO2Value < 20)
                        {
                            SO2Grade = 100;
                        } else if(meanSO2Value > 500) {
                            SO2Grade = 0;
                        }
                        else {
                            SO2Grade = (500 - meanSO2Value) / 480 * 100;
                        }

                        float meanO3Value = GradePointOneFilter(latitude, longitude, "ozon", airOnly);
                        float O3Grade;

                        if (meanO3Value < 30)
                        {
                            O3Grade = 100;
                        } else if (meanO3Value > 240) {
                            O3Grade = 0;
                        }
                        else {
                            O3Grade = (240 - meanO3Value) / 210 * 100;
                        }
                        float meanPM10Value = GradePointOneFilter(latitude, longitude, "pył zawieszony PM10", airOnly);
                        float PM10Grade;

                        if (meanPM10Value < 10)
                        {
                            PM10Grade = 100;
                        }
                        else if (meanPM10Value > 150)
                        {
                            PM10Grade = 0;
                        }
                        else {
                            PM10Grade = (150 - meanPM10Value) / 140 * 100;
                        }
                        float meanPM25Value = GradePointOneFilter(latitude, longitude, "pył zawieszony PM2.5", airOnly);
                        float PM25Grade;

                        if (meanPM25Value < 10)
                        {
                            PM25Grade = 100;
                        }
                        else if (meanPM25Value > 110)
                        {
                            PM25Grade = 0;
                        }
                        else {
                            PM25Grade = (110 - meanPM25Value) / 100 * 100;
                        }
                        float meanCOValue = GradePointOneFilter(latitude, longitude, "tlenek węgla", airOnly);
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
                    }
                case "woda":
                    {
                        var waterOnly = measures.Where(m => m.Measures.Where(m => m.Category == "woda").Any()).ToArray();
                        float meanHardnessValue = GradePointOneFilter(latitude, longitude, "Twardość - mg/l", waterOnly);
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


                        float meanPHValue = GradePointOneFilter(latitude, longitude, "pH", waterOnly);
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


                        float meanSodiumValue = GradePointOneFilter(latitude, longitude, "Sód", waterOnly);
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



                        float meanChloriumValue = GradePointOneFilter(latitude, longitude, "Chlorki", waterOnly);
                        float ChloriumGrade;

                        if (meanChloriumValue < 250)
                        {
                            ChloriumGrade = 100;
                        }
                        else
                        {
                            ChloriumGrade = 0;
                        }


                        float meanFluoriumValue = GradePointOneFilter(latitude, longitude, "Fluorki", waterOnly);
                        float FluoriumGrade;

                        if (meanFluoriumValue < 1.5)
                        {
                            FluoriumGrade = 100;
                        }
                        else
                        {
                            FluoriumGrade = 0;
                        }


                        float meanSulfurValue = GradePointOneFilter(latitude, longitude, "Siarczany", waterOnly);
                        float SulfurGrade;

                        if (meanSulfurValue < 250)
                        {
                            SulfurGrade = 100;
                        }
                        else
                        {
                            SulfurGrade = 0;
                        }

                        float meanHFValue = GradePointOneFilter(latitude, longitude, "Wodorowęglany", waterOnly);
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

                        float meanClValue = GradePointOneFilter(latitude, longitude, "Chlor wolny", waterOnly);
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
                        float meanNoiseValue = GradePointOneFilter(latitude, longitude, "poziom hałasu", measures);
                        float NoiseGrade;

                        if (meanNoiseValue < 50)
                        {
                            NoiseGrade = 100;
                        }
                        else if(meanNoiseValue < 120)
                        {
                            NoiseGrade = (120 - meanNoiseValue) / 70 * 100;
                        }
                        else
                        {
                            NoiseGrade = 0;
                        }



                        return NoiseGrade;
                    }
                case "światło":
                    {
                        float meanLigthValue = GradePointOneFilter(latitude, longitude, "poziom światła", measures);
                        float LigthGrade;

                        if (meanLigthValue < 0.5)
                        {
                            LigthGrade = 100;
                        }
                        else if (meanLigthValue < 8)
                        {
                            LigthGrade = (8 - meanLigthValue) / (float)7.5 * 100;
                        }
                        else
                        {
                            LigthGrade = 0;
                        }



                        return LigthGrade;
                    }
                case "piece":
                    {
                        break;
                    }
                default: {
                        return -1;
                    }
            }
            
            return -1;
        }

        public async Task<EcoDetails[]> GetAllDetails(float startLat, float startLon, float endLat, float endLon, float deltaLat, float deltaLon)
        {
            int recordsNumLat = (int)((endLat - startLat)/deltaLat) + 1;
            int recordsNumLon = (int)((endLon - startLon)/deltaLon) + 1;
            int len = recordsNumLat * recordsNumLon;

            EcoDetails[] details = new EcoDetails[len];
            var measures = await _measureRepository.GetAllStationsWithMeasures();

            int iter = 0;
            for (float i = startLat; i < endLat; i += deltaLat)
            {
                for (float j = startLat; j < endLon; j += deltaLon)
                {
                    EcoDetails newDetail = new EcoDetails
                    {
                        Latitude = i,
                        Longitude = j,
                        AirScore = await FilterGrade(i, j, "powietrze", measures),
                        SoundScore = await FilterGrade(i, j, "hałas", measures),
                        WaterScore = await FilterGrade(i, j, "woda", measures),
                        LightScore = await FilterGrade(i, j, "światło", measures)
                    };
                    newDetail.CalculateOverallScore();

                    details[iter++] = newDetail;
                }
            }

            return details;
        }

        public float GradePointOneFilter(float latitude, float longitude, string filter, Station[] stations)
        {
            var closestStations = GetClosestStationsWithFilter(filter, latitude, longitude, 4, stations);

            float fullDistance = 0;
            foreach (var station in closestStations)
            {
                foreach (var measure in station.Measures)
                {
                    fullDistance += GetDistance(station.Latitude, station.Longitude, latitude, longitude);
                }
            }
            float resultValue=0;
            foreach (var station in closestStations)
            {
                foreach (var measure in station.Measures)
                {
                    resultValue += (float)measure.Value * GetDistance(station.Latitude, station.Longitude, latitude, longitude) / fullDistance;
                }
            }

            return resultValue;
        }


        private List<Station> GetClosestStationsWithFilter(string filter, float latitude, float longitude,int maxClosestPoints, Station[] stations)
        {
            var chosen_station = stations.Where(m => m.Measures.Where(m => m.Sensing == filter).Any()).ToArray();
            List<Station> closestStations = new List<Station>(maxClosestPoints);
            List<float> closestDistances = new List<float>(maxClosestPoints);

            foreach (var station in chosen_station)
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
