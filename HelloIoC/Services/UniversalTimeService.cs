namespace HelloIoC.Services
{
    public class UniversalTimeService : ITimeService
    {
        public string GetTime()
        {
            return DateTime.UtcNow.ToUniversalTime().ToString();
        }
    }
}
