namespace HelloIoC.Services
{
    public class AwesomeService : IAwesomeService
    {
        private readonly ITimeService _timeService;

        public AwesomeService(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public void DoSomething()
        {
            Console.WriteLine("Hallo, heute ist es so spaet: " + _timeService.GetTime());
        }
    }
}
