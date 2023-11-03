namespace LinqEruption;
class Program
{
    static void Main(string[] args)
    {
        List<Eruption> eruptions = new List<Eruption>()
        {
            new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
            new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
            new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
            new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
            new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
            new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
            new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
            new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
            new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
            new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
            new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
            new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
            new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
        };
        // Example Query - Prints all Stratovolcano eruptions
        IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
        PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
        // Execute Assignment Tasks here!

        // Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
        static void PrintEach(IEnumerable<dynamic> items, string msg = "")
        {
            Console.WriteLine("\n" + msg);
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }

            
        }
        
        Console.WriteLine("First Eruption in Chile\n");
        
        Eruption? FirstEruptionInChile = eruptions.OrderBy(e => e.Year).FirstOrDefault(e => e.Location == "Chile");
        Console.WriteLine(FirstEruptionInChile?.ToString());


        IEnumerable<Eruption> EruptionsInHawaii = eruptions.Where(e => e.Location == "Hawaiian Is");
        PrintEruptionsInHawaii(EruptionsInHawaii);
        static void PrintEruptionsInHawaii (IEnumerable<dynamic> items)
        {
            if (!items.Any())
            {
                Console.WriteLine("No Hawaiian Is Eruption found");
            }
            else
            {
                Console.WriteLine("Eruptions in Hawaii");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }


        Console.WriteLine("First Eruption in New Zealand after 1900\n");

        Eruption? FirstEruptionInNZAfter1900 = eruptions.OrderBy(e => e.Year).FirstOrDefault(e => e.Location == "New Zealand" && e.Year > 1900);
        Console.WriteLine(FirstEruptionInNZAfter1900?.ToString());


        IEnumerable<Eruption> VolcanosEruptionHigherThan2000 = eruptions.Where(e => e.ElevationInMeters > 2000);
        PrintVolcanosEruptionHigherThan2000(VolcanosEruptionHigherThan2000);
        static void PrintVolcanosEruptionHigherThan2000 (IEnumerable<dynamic> items)
        {
            if (!items.Any())
            {
                Console.WriteLine("No Volcanos Eruption Higher Than 2000 found");
            }
            else
            {
                Console.WriteLine("Volcanos Eruption Higher Than 2000");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        IEnumerable<Eruption> VolcanoesStartingWithLetterL = eruptions.Where(e => e.Volcano.StartsWith("L"));
        PrintVolcanoesStartingWithLetterL(VolcanoesStartingWithLetterL);
        static void PrintVolcanoesStartingWithLetterL (IEnumerable<dynamic> items)
        {
            if (!items.Any())
            {
                Console.WriteLine("No Volcanoes Starting With Letter L found");
            }
            else
            {
                Console.WriteLine("Volcanoes Starting With Letter L");
                Console.WriteLine($"{items.Count()} volcanoes have been found");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        int HighestElevation = eruptions.Max(e => e.ElevationInMeters);

        Eruption? HighestElevationEruption = eruptions.Find(e => e.ElevationInMeters == HighestElevation);
        Console.WriteLine($"Highest Elevation Volcano: {HighestElevation}, {HighestElevationEruption?.Volcano} Volcano");
        // Console.WriteLine(HighestElevationEruption?.Volcano);

        IEnumerable<Eruption> EruptionsAlphabeticalOrder = eruptions.OrderBy(e => e.Volcano);
        PrintEach(EruptionsAlphabeticalOrder, "Eruptions in Alphabetical Order");


        //part1
        IEnumerable<Eruption> EruptionsBefore1000 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
        PrintEach(EruptionsBefore1000, "Eruptions Before 1000");
        //part 2
        IEnumerable<string> VolcanosBefore1000 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano);
        PrintEach(VolcanosBefore1000, "Eruptions Before 1000");
    }
}
