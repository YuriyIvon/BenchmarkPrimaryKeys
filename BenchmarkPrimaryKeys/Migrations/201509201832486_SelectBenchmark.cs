namespace BenchmarkPrimaryKeys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SelectBenchmark : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoIncrementIntKeyChildEntity1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AutoIncrementIntKeyParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.AutoIncrementIntKeyParentEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AutoIncrementIntKeyChildEntity2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AutoIncrementIntKeyParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.AutoIncrementIntKeyChildEntity3",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AutoIncrementIntKeyParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.AutoIncrementIntKeyChildEntity4",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AutoIncrementIntKeyParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.AutoIncrementIntKeyChildEntity5",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AutoIncrementIntKeyParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GuidKeyNonSequentialChildEntity1",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(maxLength: 4000),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuidKeyNonSequentialParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GuidKeyNonSequentialParentEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuidKeyNonSequentialChildEntity2",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(maxLength: 4000),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuidKeyNonSequentialParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GuidKeyNonSequentialChildEntity3",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(maxLength: 4000),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuidKeyNonSequentialParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GuidKeyNonSequentialChildEntity4",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(maxLength: 4000),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuidKeyNonSequentialParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GuidKeyNonSequentialChildEntity5",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(maxLength: 4000),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuidKeyNonSequentialParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GuidKeySequentialChildEntity1",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuidKeySequentialParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GuidKeySequentialParentEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuidKeySequentialChildEntity2",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuidKeySequentialParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GuidKeySequentialChildEntity3",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuidKeySequentialParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GuidKeySequentialChildEntity4",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuidKeySequentialParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GuidKeySequentialChildEntity5",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuidKeySequentialParentEntities", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GuidKeySequentialChildEntity5", "ParentId", "dbo.GuidKeySequentialParentEntities");
            DropForeignKey("dbo.GuidKeySequentialChildEntity4", "ParentId", "dbo.GuidKeySequentialParentEntities");
            DropForeignKey("dbo.GuidKeySequentialChildEntity3", "ParentId", "dbo.GuidKeySequentialParentEntities");
            DropForeignKey("dbo.GuidKeySequentialChildEntity2", "ParentId", "dbo.GuidKeySequentialParentEntities");
            DropForeignKey("dbo.GuidKeySequentialChildEntity1", "ParentId", "dbo.GuidKeySequentialParentEntities");
            DropForeignKey("dbo.GuidKeyNonSequentialChildEntity5", "ParentId", "dbo.GuidKeyNonSequentialParentEntities");
            DropForeignKey("dbo.GuidKeyNonSequentialChildEntity4", "ParentId", "dbo.GuidKeyNonSequentialParentEntities");
            DropForeignKey("dbo.GuidKeyNonSequentialChildEntity3", "ParentId", "dbo.GuidKeyNonSequentialParentEntities");
            DropForeignKey("dbo.GuidKeyNonSequentialChildEntity2", "ParentId", "dbo.GuidKeyNonSequentialParentEntities");
            DropForeignKey("dbo.GuidKeyNonSequentialChildEntity1", "ParentId", "dbo.GuidKeyNonSequentialParentEntities");
            DropForeignKey("dbo.AutoIncrementIntKeyChildEntity5", "ParentId", "dbo.AutoIncrementIntKeyParentEntities");
            DropForeignKey("dbo.AutoIncrementIntKeyChildEntity4", "ParentId", "dbo.AutoIncrementIntKeyParentEntities");
            DropForeignKey("dbo.AutoIncrementIntKeyChildEntity3", "ParentId", "dbo.AutoIncrementIntKeyParentEntities");
            DropForeignKey("dbo.AutoIncrementIntKeyChildEntity2", "ParentId", "dbo.AutoIncrementIntKeyParentEntities");
            DropForeignKey("dbo.AutoIncrementIntKeyChildEntity1", "ParentId", "dbo.AutoIncrementIntKeyParentEntities");
            DropIndex("dbo.GuidKeySequentialChildEntity5", new[] { "ParentId" });
            DropIndex("dbo.GuidKeySequentialChildEntity4", new[] { "ParentId" });
            DropIndex("dbo.GuidKeySequentialChildEntity3", new[] { "ParentId" });
            DropIndex("dbo.GuidKeySequentialChildEntity2", new[] { "ParentId" });
            DropIndex("dbo.GuidKeySequentialChildEntity1", new[] { "ParentId" });
            DropIndex("dbo.GuidKeyNonSequentialChildEntity5", new[] { "ParentId" });
            DropIndex("dbo.GuidKeyNonSequentialChildEntity4", new[] { "ParentId" });
            DropIndex("dbo.GuidKeyNonSequentialChildEntity3", new[] { "ParentId" });
            DropIndex("dbo.GuidKeyNonSequentialChildEntity2", new[] { "ParentId" });
            DropIndex("dbo.GuidKeyNonSequentialChildEntity1", new[] { "ParentId" });
            DropIndex("dbo.AutoIncrementIntKeyChildEntity5", new[] { "ParentId" });
            DropIndex("dbo.AutoIncrementIntKeyChildEntity4", new[] { "ParentId" });
            DropIndex("dbo.AutoIncrementIntKeyChildEntity3", new[] { "ParentId" });
            DropIndex("dbo.AutoIncrementIntKeyChildEntity2", new[] { "ParentId" });
            DropIndex("dbo.AutoIncrementIntKeyChildEntity1", new[] { "ParentId" });
            DropTable("dbo.GuidKeySequentialChildEntity5");
            DropTable("dbo.GuidKeySequentialChildEntity4");
            DropTable("dbo.GuidKeySequentialChildEntity3");
            DropTable("dbo.GuidKeySequentialChildEntity2");
            DropTable("dbo.GuidKeySequentialParentEntities");
            DropTable("dbo.GuidKeySequentialChildEntity1");
            DropTable("dbo.GuidKeyNonSequentialChildEntity5");
            DropTable("dbo.GuidKeyNonSequentialChildEntity4");
            DropTable("dbo.GuidKeyNonSequentialChildEntity3");
            DropTable("dbo.GuidKeyNonSequentialChildEntity2");
            DropTable("dbo.GuidKeyNonSequentialParentEntities");
            DropTable("dbo.GuidKeyNonSequentialChildEntity1");
            DropTable("dbo.AutoIncrementIntKeyChildEntity5");
            DropTable("dbo.AutoIncrementIntKeyChildEntity4");
            DropTable("dbo.AutoIncrementIntKeyChildEntity3");
            DropTable("dbo.AutoIncrementIntKeyChildEntity2");
            DropTable("dbo.AutoIncrementIntKeyParentEntities");
            DropTable("dbo.AutoIncrementIntKeyChildEntity1");
        }
    }
}
