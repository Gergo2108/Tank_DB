namespace K9P4EG_HFT_2022231.Logic
{
    public class CountryStatistic
    {
        public string CountryName { get; set; }
        public int TankCount { get; set; }
      

        public override bool Equals(object obj)
        {
            return obj is CountryStatistic statistic &&
                CountryName == statistic.CountryName &&
                TankCount == statistic.TankCount;
               
        }

        public override string ToString()
        {
            return $"Name = {CountryName}, TankCount = {TankCount}";
        }
    }
}