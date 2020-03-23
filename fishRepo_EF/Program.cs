using FishDumpRepo;
using System;
using System.IO;
using System.Linq;

namespace fishRepo_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FishDumpContext())
            {
                using (var reader = new StreamReader(@"D:/Fish Dump.csv"))
                {
                    // Throw away the header
                    _ = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        // Parses line from the file into an array/list of values
                        var result = line.Split(',').Select(c => c.TrimEnd()).ToArray();

                        // Check for existing region
                        var region = db.Regions.Where(a => a.Regions == result[0])
                                               .SingleOrDefault();

                        // Add region if none existed
                        if (region == null)
                        {
                            // Set Region contents from the CSV row
                            var newRegion = new Region() { Regions = result[0] };

                            db.Add(newRegion);
                            db.SaveChanges(); // Never forget to save changes

                            // Single here (no default) as the row is known to exist at this point if an exception was not thrown by SaveChanges
                            region = db.Regions.Where(a => a.Regions == result[0]).Single();

                            Console.WriteLine($"Added region {region.Regions} with Id {region.RegionID}"); // Should see this one time
                        }

                        Console.WriteLine($"Region {region.Regions} has Id {region.RegionID}"); // Should see this every time
                    }
                }
            }
        }
    }
}
