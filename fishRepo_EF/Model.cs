using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FishDumpRepo
{
    public class FishDumpContext : DbContext
    {
        public DbSet<SubRegion> SubRegions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<FishName> FishName { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=fishDump.db");
    }

    public class SubRegion
    {
        public int SubRegionID { get; set; }
        public string FishID { get; set; }
        public string SubRegions { get; set; }

    }

    public class Region
    {
        public int RegionID { get; set; }
        public string FishID { get; set; }
        public string Regions { get; set; }

        public List<SubRegion> SubRegions { get; } = new List<SubRegion>();

    }

    public class Locations
    {
        public int LocationsID { get; set; }
        public string StudyAreas { get; set; }
        public string Longtitude { get; set; }
        public int FishLocaID { get; set; }
        public string Latitude { get; set; }
        public string FishID { get; set; }
        public List<Region> Regions { get; } = new List<Region>();

    }

    public class FishName
    {
        public string FishNameID { get; set; }
        public string Family { get; set; }
        public string SpecificName { get; set; }
        public int CommonName { get; set; }
        public string FishID { get; set; }

        public List<Characteristic> Characteristics  { get; } = new List<Characteristic>();
    }

    public class Survey
    {
        public string SurveyID { get; set; }
        public string SurveyDate { get; set; }
        public string SurveyIndex { get; set; }
        public int Management { get; set; }
        public string BatchCode { get; set; }
        public string FishID { get; set; }

        public List<Locations> Locations { get; } = new List<Locations>();
    }
    public class Characteristic
    {

        public string CharacteristicID { get; set; }
        public string FishLength { get; set; }
        public string Trophic { get; set; }
        public string FishID { get; set; }
        public int StructureType { get; set; }
        public string FishCount { get; set; }

        public List<Locations> Locations { get; } = new List<Locations>();


    }
}
