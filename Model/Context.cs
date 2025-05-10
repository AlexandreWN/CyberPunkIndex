using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<SubType> SubType { get; set; }
        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
            });

            modelBuilder.Entity<SubType>(entity =>
            {
                entity.ToTable("SubType");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
                entity.Property(x => x.IdType).IsRequired();

                entity.HasOne(x => x.ItemType)
                      .WithMany()
                      .HasForeignKey(x => x.IdType);
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.ToTable("Producer");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
                entity.Property(x => x.Price).HasColumnType("decimal(18,2)");
                entity.Property(x => x.Source);

                entity.HasOne(x => x.SubType)
                      .WithMany()
                      .HasForeignKey(x => x.IdSubType);

                entity.HasOne(x => x.Category)
                      .WithMany()
                      .HasForeignKey(x => x.IdCategory);

                entity.HasOne(x => x.Producer)
                      .WithMany()
                      .HasForeignKey(x => x.IdProducer);
            });
        }
    }
}
