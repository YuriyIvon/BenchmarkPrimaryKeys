using System.Data.Entity;

namespace BenchmarkPrimaryKeys
{
    class EntityDataContext : DbContext
    {
        public DbSet<GuidKeyDbSequentialEntity> GuidKeyDbSequentialEntities { get; set; }

        public DbSet<GuidKeyDbNonSequentialEntity> GuidKeyDbNonSequentialEntities { get; set; }

        public DbSet<GuidKeyClientNonSequentialEntity> GuidKeyClientNonSequentialEntities { get; set; }

        public DbSet<GuidKeyClientSequentialEntity> GuidKeyClientSequentialEntities { get; set; }

        public DbSet<AutoIncrementIntKeyEntity> AutoIncrementIntKeyEntities { get; set; }

        public EntityDataContext() : base("name=Entities")
        {

        }
    }
}
