namespace HackstreeetServer.src.Services
{
    public interface IEcoGraderService
    {
        public Task<float> FilterGrade(float latitude, float longitude, string categoryFilter);
    }
}
