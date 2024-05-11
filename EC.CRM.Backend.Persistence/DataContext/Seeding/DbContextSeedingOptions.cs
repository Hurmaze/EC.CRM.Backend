namespace EC.CRM.Backend.Persistence.DataContext.Seeding
{
    public class DbContextSeedingOptions
    {
        public const string Name = "DbContextSeedingOptions";

        public bool SeedBasicData { get; set; }
        public bool SeedTestData { get; set; }
        public string? SqlSeederPath { get; set; }
    }
}
