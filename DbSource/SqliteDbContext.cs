using Backend.Models;
using System.Data.Entity;
using System.Data.SQLite;

namespace Backend
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = "citystatecountry.db" }.ConnectionString
            }, true)
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    this.OnModelCreatingTable(modelBuilder.Entity<Country>());
        //    this.OnModelCreatingTable(modelBuilder.Entity<State>());
        //    this.OnModelCreatingTable(modelBuilder.Entity<City>());

        //    this.OnModelCreatingTableRelations(modelBuilder);

        //    base.OnModelCreating(modelBuilder);
        //}

        //private void OnModelCreatingTable(EntityTypeConfiguration<City> cities)
        //{
        //    cities.ToTable(nameof(SqliteDbContext.City)).HasKey(city => city.CityId);
        //    cities.Property(city => city.CityName).IsRequired();
        //    cities.Property(city => city.Population).IsOptional();
        //    cities.Property(city => city.StateId).IsRequired();
        //}

        //private void OnModelCreatingTable(EntityTypeConfiguration<State> states)
        //{
        //    states.ToTable(nameof(SqliteDbContext.State)).HasKey(state => state.StateId);
        //    states.Property(state => state.StateName).IsRequired();
        //    states.Property(state => state.CountryId).IsRequired();
        //}

        //private void OnModelCreatingTable(EntityTypeConfiguration<Country> countries)
        //{
        //    countries.ToTable(nameof(SqliteDbContext.Country)).HasKey(country => country.CountryId);
        //    countries.Property(country => country.CountryName).IsRequired();
        //}

        //private void OnModelCreatingTableRelations(DbModelBuilder modelBuilder)
        //{
        //    // State <--> City: One-to-Many
        //    modelBuilder.Entity<State>()
        //        .HasMany(state => state.Cities);

        //    // Country <--> State: One-To-Many
        //    modelBuilder.Entity<Country>()
        //        .HasMany(country => country.States);
        //}

        public DbSet<Country> Country { get; set; }

        public DbSet<State> State { get; set; }

        public DbSet<City> City { get; set; }
    }
}
