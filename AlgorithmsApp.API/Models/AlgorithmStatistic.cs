namespace AlgorithmsApp.API.Models
{
    public class AlgorithmStatistic
    {
        public int Id { get; set;}
        public int AlgorithmId { get; set; }
        public int MockDataId { get; set; }

        public Algorithm Algorithm { get; set; }
        public MockData MockData { get; set; }
    }
}