using System.Collections.Generic;

namespace AlgorithmsApp.API.Dtos
{
    public class AlgStatistic
    {
        public int AlgId { get; set; }
        public string AlgName { get; set; }

        public List<Statistic> Statistics {get; set;}
        
    }
}