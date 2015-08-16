namespace BenchmarkPrimaryKeys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoIncrementIntKeyEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuidKeyClientNonSequentialEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 4000),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuidKeyClientSequentialEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 4000),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuidKeyDbNonSequentialEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(maxLength: 4000),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuidKeyDbSequentialEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuidKeyDbSequentialEntities");
            DropTable("dbo.GuidKeyDbNonSequentialEntities");
            DropTable("dbo.GuidKeyClientSequentialEntities");
            DropTable("dbo.GuidKeyClientNonSequentialEntities");
            DropTable("dbo.AutoIncrementIntKeyEntities");
        }
    }
}
