namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogError("It was less than 3");
                return null;
            }

            double Latitude = double.Parse(cells[0]);
            double Longitude = double.Parse(cells[1]);
            string Name = cells[2];
            // Do not fail if one record parsing fails, return null
            TacoBell newTacoBell = new TacoBell();

            newTacoBell.Name = cells[2];
            Point pointStorage = new Point();
            pointStorage.Latitude = Latitude;
            pointStorage.Longitude = Longitude;
            newTacoBell.Location = pointStorage;

            return newTacoBell; // TODO Implement
        }
    }
    public class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}