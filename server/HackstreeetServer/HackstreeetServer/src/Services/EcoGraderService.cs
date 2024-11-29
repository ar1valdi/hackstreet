using HackstreeetServer.src.Models.Measures;
using HackstreeetServer.src.Repositories;

namespace HackstreeetServer.src.Services
{
    public class EcoGraderService
    {
        IMeasureRepository _measureRepository;

        public EcoGraderService(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
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
