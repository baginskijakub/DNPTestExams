using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Domain;

namespace WebAPI.EfcDataAccess;

public class Context : DbContext
{
    public DbSet<Child> Children { get; set; }
    public DbSet<Toy> Toys { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Context.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    public async Task<Child> AddChildAsync(Child child)
    {
        EntityEntry<Child> newChild = await Children.AddAsync(child);
        await SaveChangesAsync();
        return newChild.Entity;
    }
    
    public async Task<Toy> AddToyAsync(Toy toy)
    {
        EntityEntry<Toy> newToy = await Toys.AddAsync(toy);
        await SaveChangesAsync();
        return newToy.Entity;
    }

    public async Task<List<int>> GetChildrenId()
    {
        List<Child> childrenList = await Children.ToListAsync();
        List<int> list = new List<int>();
        foreach (var child in childrenList)
        {
            list.Add(child.Id);
        }

        return list;
    }

    public async Task<List<Child>> GetChildren()
    {
        List<Child> childrenList = await Children.ToListAsync();
        List<Toy> toyList = await Toys.ToListAsync();
        foreach (var child in childrenList)
        {
            child.toys = new List<Toy>();
            foreach (var toy in toyList)
            {
                if (child.Id == toy.OwnerId)
                {
                    child.toys.Add(toy);
                } 
            }
        }

        return childrenList;
    }

    public async Task<bool> DeleteToy(int id)
    {
        List<Toy> toyList = await Toys.ToListAsync();
        bool status = false;
        foreach (var toy in toyList)
        {
            if (toy.Id == id)
            {
                Toys.Remove(toy);
                status = true;
            } 
        }

        SaveChangesAsync();
        return status;
    }
}