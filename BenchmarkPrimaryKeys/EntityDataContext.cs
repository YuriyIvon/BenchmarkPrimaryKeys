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

        public DbSet<GuidKeySequentialParentEntity> GuidKeySequentialParentEntities { get; set; }

        public DbSet<GuidKeySequentialChildEntity1> GuidKeySequentialChildEntities1 { get; set; }

        public DbSet<GuidKeySequentialChildEntity2> GuidKeySequentialChildEntities2 { get; set; }

        public DbSet<GuidKeySequentialChildEntity3> GuidKeySequentialChildEntities3 { get; set; }

        public DbSet<GuidKeySequentialChildEntity4> GuidKeySequentialChildEntities4 { get; set; }

        public DbSet<GuidKeySequentialChildEntity5> GuidKeySequentialChildEntities5 { get; set; }

        public DbSet<GuidKeyNonSequentialParentEntity> GuidKeyNonSequentialParentEntities { get; set; }

        public DbSet<GuidKeyNonSequentialChildEntity1> GuidKeyNonSequentialChildEntities1 { get; set; }

        public DbSet<GuidKeyNonSequentialChildEntity2> GuidKeyNonSequentialChildEntities2 { get; set; }

        public DbSet<GuidKeyNonSequentialChildEntity3> GuidKeyNonSequentialChildEntities3 { get; set; }

        public DbSet<GuidKeyNonSequentialChildEntity4> GuidKeyNonSequentialChildEntities4 { get; set; }

        public DbSet<GuidKeyNonSequentialChildEntity5> GuidKeyNonSequentialChildEntities5 { get; set; }

        public DbSet<AutoIncrementIntKeyParentEntity> AutoIncrementIntKeyParentEntities { get; set; }

        public DbSet<AutoIncrementIntKeyChildEntity1> AutoIncrementIntKeyChildEntities1 { get; set; }

        public DbSet<AutoIncrementIntKeyChildEntity2> AutoIncrementIntKeyChildEntities2 { get; set; }

        public DbSet<AutoIncrementIntKeyChildEntity3> AutoIncrementIntKeyChildEntities3 { get; set; }

        public DbSet<AutoIncrementIntKeyChildEntity4> AutoIncrementIntKeyChildEntities4 { get; set; }

        public DbSet<AutoIncrementIntKeyChildEntity5> AutoIncrementIntKeyChildEntities5 { get; set; }

        public EntityDataContext() : base("name=Entities")
        {

        }
    }
}
