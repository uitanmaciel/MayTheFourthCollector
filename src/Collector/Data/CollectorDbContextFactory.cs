using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Collector.Data;

public class CollectorDbContextFactory : IDesignTimeDbContextFactory<CollectorContext>
{
    public CollectorContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CollectorContext>();
        optionsBuilder.UseSqlite("Data Source=C:/Users/Uitan Maciel/Documents/Projects/MayTheFourthCollector/src/Collector/maythefourth.db");

        return new CollectorContext(optionsBuilder.Options);
    }
}