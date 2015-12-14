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
        public DbSet<User>               Users               { get; set; }
        public DbSet<Role>               Roles               { get; set; }
        public DbSet<Permission>         Permissions         { get; set; }

        public DbSet<Action>             Actions             { get; set; }
        public DbSet<UserAction>         User_Action         { get; set; }

        //Import
        public DbSet<ColumnHeaderClient> ColumnHeader_Client { get; set; }
        public DbSet<ColumnHeader>       ColumnHeaders       { get; set; }
        public DbSet<GoodColumn>         GoodColumns         { get; set; }
        public DbSet<ImportType>         ImportTypes         { get; set; }

        //Clients
        public DbSet<Client>          Clients         { get; set; }
        //Projects
        public DbSet<Project>         Projects        { get; set; }


        //Asterisk
        public virtual DbSet<AsteriskSipPeer> AsteriskSipPeers { get; set; }
        public virtual DbSet<AsteriskQueue> AsteriskQueues { get; set; }
        public virtual DbSet<AsteriskCallDetail> AsteriskCallDetails { get; set; }
        public virtual DbSet<AsteriskBlacklist> AsteriskBlacklists { get; set; }
        public virtual DbSet<AsteriskExtension> AsteriskExtensions { get; set; }

        public virtual DbSet<AsteriskMttCode> AsteriskMttCodes { get; set; }
        public virtual DbSet<ast_mtt_operators_tr> ast_mtt_operators_tr { get; set; }
        public virtual DbSet<ast_mtt_regions_tr> ast_mtt_regions_tr { get; set; }

        public virtual DbSet<AsteriskInbound> AsteriskInbounds { get; set; }
        public virtual DbSet<AsteriskMusicOnHold> AsteriskMusicOnHolds { get; set; }
        public virtual DbSet<AsteriskQueueMember> AsteriskQueueMembers { get; set; }
        public virtual DbSet<AsteriskQueueRule> AsteriskQueueRules { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //configure model with fluent API
            // User - Action relation
            modelBuilder.Entity<UserAction>()
                .ToTable("User_Action")
                .HasKey(ua => new { ua.UserId, ua.ActionId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.User_Action)
                .WithRequired()
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<Action>()
                .HasMany(a => a.UserActions)
                .WithRequired()
                .HasForeignKey(ua => ua.ActionId);

            // ColumnHeader - Client relations
            modelBuilder.Entity<ColumnHeaderClient>()
                .ToTable("ColumnHeader_Client")
                .HasKey(ch => new { ch.ColumnHeaderId, ch.ClientId });

            modelBuilder.Entity<ColumnHeader>()
                .HasMany(ch => ch.ColumnHeader_Client)
                .WithRequired()
                .HasForeignKey(chc => chc.ColumnHeaderId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.ColumnHeader_Client)
                .WithRequired()
                .HasForeignKey(c => c.ClientId);
        }
    }
}
