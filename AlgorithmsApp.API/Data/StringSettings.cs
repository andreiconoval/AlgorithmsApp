using Microsoft.Extensions.Configuration;

namespace AlgorithmsApp.API.Data
{
    public class StringSettings
    {
        private IConfiguration _configuration;
        private string _schedule { get; set; }

        public StringSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetSchedule() {
            if(_schedule == null){
                _schedule = _configuration.GetSection("StringSettings").GetSection("Schedule").Value;
            }

            return _schedule;

        }
    }
}