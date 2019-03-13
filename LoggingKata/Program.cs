using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable firstTacoBell = null;
            ITrackable secondTacoBell = null;
            double distance = 0;


            for (int i = 0; i < locations.Length; i++)
            {
                ITrackable locA = locations[i];
                GeoCoordinate corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                for (int x = 1; x < locations.Length; x++)
                {
                    ITrackable locB = locations[x];
                    GeoCoordinate corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        firstTacoBell = locA;
                        secondTacoBell = locB;
                    }

                }
            }
            Console.WriteLine(firstTacoBell.Name);
            Console.WriteLine(secondTacoBell.Name);
            Console.ReadLine();
        }

        // TODO:  Find the two Taco Bells that are the furthest from one another.
        // HINT:  You'll need two nested forloops
    }
}
