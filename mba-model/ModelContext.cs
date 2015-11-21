using System.Data.Entity;

namespace mba_model
{
    public class ModelContext : DbContext
    {
        static void Main(string[] args)
        {
        }

        public ModelContext() : base("name=mbafDB")
        {
        }

        //Permission
        public DbSet<User>            Users           { get; set; }
        public DbSet<Role>            Roles           { get; set; }
        public DbSet<Permission>      Permissions     { get; set; }

        public DbSet<Action>          Actions         { get; set; }
        public DbSet<UserAction>      UserActions     { get; set; }

        //Import
        public DbSet<ColumnHeader>    ColumnHeaders   { get; set; }
        public DbSet<GoodColumn>      GoodColumns     { get; set; }
        public DbSet<ImportType>      ImportTypes     { get; set; }

        //Clients
        public DbSet<Client>          Clients         { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //configure model with fluent API
            modelBuilder.Entity<UserAction>()
                        .HasKey(ua => new { ua.UserId, ua.ActionId, ua.Created});

            modelBuilder.Entity<User>()
                        .HasMany(u => u.UserActions)
                        .WithRequired()
                        .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<Action>()
                        .HasMany(a => a.UserActions)
                        .WithRequired()
                        .HasForeignKey(ua => ua.ActionId);
        }
    }
}
