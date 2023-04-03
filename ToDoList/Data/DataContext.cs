using ToDoList.model;

namespace ToDoList.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<DoingItem> DoingItems { get; set; }
        public DbSet<DoneItem> DoneItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>().HasData(
                new ToDoItem { Id=1, Text = "get groceries" }
                );

            modelBuilder.Entity<DoingItem>().HasData(
                new DoingItem { Id = 1, Text = "read newspaper" }
                );

            modelBuilder.Entity<DoneItem>().HasData(
                new DoneItem {Id = 1, Text = "wash the dishes" }
                );
        }
    }
}
