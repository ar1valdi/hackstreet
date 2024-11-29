namespace HackstreeetServer.src.Models
{
    public class EcoDetails
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float? OverallScore { get; set; }
        public float? SoundScore { get; set; }
        public float? AirScore { get; set; }
        public float? WaterScore { get; set; }
        public float? LightScore {  get; set; }
    
        public void CalculateOverallScore()
        {
            int cnt = 0;
            float avg = 0;


            
            UpdateAvg(ref cnt, ref avg, SoundScore);
            UpdateAvg(ref cnt, ref avg, AirScore);
            UpdateAvg(ref cnt, ref avg, WaterScore);
            UpdateAvg(ref cnt, ref avg, LightScore);

            OverallScore =  avg / (float)cnt;
        }

        private void UpdateAvg(ref int cnt, ref float sum, float? x)
        {
            if (x != null)
            {
                sum += (float)x;
                cnt += 1;
            }
        }
    }
}
