using System.Data.Entity;

namespace mba_model
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base ("name=mbafDB")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        static void Main(string[] args)
        {
            using (ModelContext mcontext = new ModelContext())
            {
                Role r = new Role { Name = "administrator", ScreenName = "Администратор системы" };
                mcontext.Roles.Add(r);
                mcontext.SaveChanges();
            }
        }
    }
}
