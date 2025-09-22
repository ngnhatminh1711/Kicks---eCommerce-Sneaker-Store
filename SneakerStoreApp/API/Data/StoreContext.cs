using Microsoft.EntityFrameworkCore;
using SneakerStoreApp.API.Models;

namespace SneakerStoreApp.API.Data;

public class StoreContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Product> Products { get; set; }
}