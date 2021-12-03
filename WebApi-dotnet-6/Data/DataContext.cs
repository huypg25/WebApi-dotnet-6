using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace WebApi_dotnet_6.Data
{
    public class DataContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public Microsoft.EntityFrameworkCore.DbSet<Item> items { get; set; } 
    }
}
