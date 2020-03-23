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
    }

    public class Locations
    {
        public string StudyAreas { get; set; }
        public string Longtitude { get; set; }
        public int FishLocaID { get; set; }
        public string Latitude { get; set; }
        public string FishID { get; set; }

    }

    public class FishName
    {
        public string FishNameID { get; set; }
        public string Family { get; set; }
        public string SpecificName { get; set; }
        public int CommonName { get; set; }
        public string FishID { get; set; }
    }

    public class Survey
    {
        public string SurveyID { get; set; }
        public string SurveyDate { get; set; }
        public string SurveyIndex { get; set; }
        public int Management { get; set; }
        public string BatchCode { get; set; }
        public string FishID { get; set; }
    }
    public class Characteristic
    {

        public string CharacteristicID { get; set; }
        public string FishLength { get; set; }
        public string Trophic { get; set; }
        public string FishID { get; set; }
        public int StructureType { get; set; }
        public string FishCount { get; set; }

    }
}
