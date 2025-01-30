using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BusinessX_Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseNpgsql("Host=192.168.1.200;Port=5432;Database=BusinessX;Username=InteLLi;Password=Lv2+Fy2t");

        return new DataContext(optionsBuilder.Options);
    }
}
