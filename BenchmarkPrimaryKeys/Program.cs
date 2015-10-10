using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace BenchmarkPrimaryKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkInserts();
            //PopulateTablesForSelects(1000);
            BenchmarkSelects();
        }

        private static void BenchmarkInserts()
        {
            int warmUpCount = 1000;
            int count = 10000;
            int stringLength = 40;

            Console.WriteLine("Warming up...");
            BenchmarkDbGeneratedSequentialGuid(warmUpCount, stringLength);
            Console.WriteLine("Inserting {0} records...", count);
            Console.WriteLine("Inserting records with DB-generated sequential GUID primary key took {0} ms",
                BenchmarkDbGeneratedSequentialGuid(count, stringLength));

            Console.WriteLine("Warming up...");
            BenchmarkDbGeneratedNonSequentialGuid(warmUpCount, stringLength);
            Console.WriteLine("Inserting {0} records...", count);
            Console.WriteLine("Inserting records with DB-generated non-sequential GUID primary key took {0} ms",
                BenchmarkDbGeneratedNonSequentialGuid(count, stringLength));

            Console.WriteLine("Warming up...");
            BenchmarkClientGeneratedSequentialGuid(warmUpCount, stringLength);
            Console.WriteLine("Inserting {0} records...", count);
            Console.WriteLine("Inserting records with client-generated sequential GUID primary key took {0} ms",
                BenchmarkClientGeneratedSequentialGuid(count, stringLength));

            Console.WriteLine("Warming up...");
            BenchmarkClientGeneratedNonSequentialGuid(warmUpCount, stringLength);
            Console.WriteLine("Inserting {0} records...", count);
            Console.WriteLine("Inserting records with client-generated non-sequential GUID primary key took {0} ms",
                BenchmarkClientGeneratedNonSequentialGuid(count, stringLength));

            Console.WriteLine("Warming up...");
            BenchmarkAutoIncrementInt(warmUpCount, stringLength);
            Console.WriteLine("Inserting {0} records...", count);
            Console.WriteLine("Inserting records with auto-increment Int primary key took {0} ms",
                BenchmarkAutoIncrementInt(count, stringLength));
        }

        private static void PopulateTablesForSelects(int count)
        {
            Console.WriteLine("Populating tables for select benchmark with {0} records", count);

            for (int i = 0; i < count; i++)
            {
                using (var dc = new EntityDataContext())
                {
                    var p1 = new GuidKeySequentialParentEntity
                    {
                        Name = "Entity" + i,
                        Children1 = new List<GuidKeySequentialChildEntity1>(),
                        Children2 = new List<GuidKeySequentialChildEntity2>(),
                        Children3 = new List<GuidKeySequentialChildEntity3>(),
                        Children4 = new List<GuidKeySequentialChildEntity4>(),
                        Children5 = new List<GuidKeySequentialChildEntity5>()
                    };
                    var p2 = new GuidKeyNonSequentialParentEntity
                    {
                        Name = "Entity" + i,
                        Children1 = new List<GuidKeyNonSequentialChildEntity1>(),
                        Children2 = new List<GuidKeyNonSequentialChildEntity2>(),
                        Children3 = new List<GuidKeyNonSequentialChildEntity3>(),
                        Children4 = new List<GuidKeyNonSequentialChildEntity4>(),
                        Children5 = new List<GuidKeyNonSequentialChildEntity5>()
                    };
                    var p3 = new AutoIncrementIntKeyParentEntity
                    {
                        Name = "Entity" + i,
                        Children1 = new List<AutoIncrementIntKeyChildEntity1>(),
                        Children2 = new List<AutoIncrementIntKeyChildEntity2>(),
                        Children3 = new List<AutoIncrementIntKeyChildEntity3>(),
                        Children4 = new List<AutoIncrementIntKeyChildEntity4>(),
                        Children5 = new List<AutoIncrementIntKeyChildEntity5>()
                    };

                    for (int j = 0; j < 10; j++)
                    {
                        var c11 = new GuidKeySequentialChildEntity1
                        {
                            Name = "Child1" + i + "_" + j
                        };
                        var c12 = new GuidKeySequentialChildEntity2
                        {
                            Name = "Child2" + i + "_" + j
                        };
                        var c13 = new GuidKeySequentialChildEntity3
                        {
                            Name = "Child3" + i + "_" + j
                        };
                        var c14 = new GuidKeySequentialChildEntity4
                        {
                            Name = "Child4" + i + "_" + j
                        };
                        var c15 = new GuidKeySequentialChildEntity5
                        {
                            Name = "Child5" + i + "_" + j
                        };

                        var c21 = new GuidKeyNonSequentialChildEntity1
                        {
                            Name = "Child1" + i + "_" + j
                        };
                        var c22 = new GuidKeyNonSequentialChildEntity2
                        {
                            Name = "Child2" + i + "_" + j
                        };
                        var c23 = new GuidKeyNonSequentialChildEntity3
                        {
                            Name = "Child3" + i + "_" + j
                        };
                        var c24 = new GuidKeyNonSequentialChildEntity4
                        {
                            Name = "Child4" + i + "_" + j
                        };
                        var c25 = new GuidKeyNonSequentialChildEntity5
                        {
                            Name = "Child5" + i + "_" + j
                        };

                        var c31 = new AutoIncrementIntKeyChildEntity1
                        {
                            Name = "Child1" + i + "_" + j
                        };
                        var c32 = new AutoIncrementIntKeyChildEntity2
                        {
                            Name = "Child2" + i + "_" + j
                        };
                        var c33 = new AutoIncrementIntKeyChildEntity3
                        {
                            Name = "Child3" + i + "_" + j
                        };
                        var c34 = new AutoIncrementIntKeyChildEntity4
                        {
                            Name = "Child4" + i + "_" + j
                        };
                        var c35 = new AutoIncrementIntKeyChildEntity5
                        {
                            Name = "Child5" + i + "_" + j
                        };

                        p1.Children1.Add(c11);
                        p1.Children2.Add(c12);
                        p1.Children3.Add(c13);
                        p1.Children4.Add(c14);
                        p1.Children5.Add(c15);

                        p2.Children1.Add(c21);
                        p2.Children2.Add(c22);
                        p2.Children3.Add(c23);
                        p2.Children4.Add(c24);
                        p2.Children5.Add(c25);

                        p3.Children1.Add(c31);
                        p3.Children2.Add(c32);
                        p3.Children3.Add(c33);
                        p3.Children4.Add(c34);
                        p3.Children5.Add(c35);
                    }

                    dc.GuidKeySequentialParentEntities.Add(p1);
                    dc.GuidKeyNonSequentialParentEntities.Add(p2);
                    dc.AutoIncrementIntKeyParentEntities.Add(p3);
                    dc.SaveChanges();
                }
            }
        }

        private static void BenchmarkSelects()
        {
            int singleRecordSelectWarmUpCount = 100;
            int singleRecordSelectCount = 10000;
            int joinSelectWarmUpCount = 1;
            int joinSelectCount = 100;
            int joinSelectAllCount = 10;

            using (var dataContext = new EntityDataContext())
            {
                //Load keys to find then
                Guid sequentialGuidKey = dataContext.GuidKeySequentialParentEntities
                    .AsNoTracking()
                    .OrderBy(e => e.Id)
                    .Select(e => e.Id)
                    .Skip(1000)
                    .FirstOrDefault();

                Guid nonSequentialGuidKey = dataContext.GuidKeyNonSequentialParentEntities
                    .AsNoTracking()
                    .OrderBy(e => e.Id)
                    .Select(e => e.Id)
                    .Skip(1000)
                    .FirstOrDefault();

                int autoIncrementKey = dataContext.AutoIncrementIntKeyParentEntities
                    .AsNoTracking()
                    .OrderBy(e => e.Id)
                    .Select(e => e.Id)
                    .Skip(1000)
                    .FirstOrDefault();

                //Benchmarking selecting single records (with child collection)
                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, singleRecordSelectWarmUpCount, 
                    c => c.GuidKeySequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .FirstOrDefault(e => e.Id == sequentialGuidKey));
                Console.WriteLine("Selecting {0} records...", singleRecordSelectCount);
                Console.WriteLine("Selecting records by sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, singleRecordSelectCount,
                        c => c.GuidKeySequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .FirstOrDefault(e => e.Id == sequentialGuidKey)));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, singleRecordSelectWarmUpCount,
                    c => c.GuidKeyNonSequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .FirstOrDefault(e => e.Id == nonSequentialGuidKey));
                Console.WriteLine("Selecting {0} records...", singleRecordSelectCount);
                Console.WriteLine("Selecting records by non-sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, singleRecordSelectCount,
                        c => c.GuidKeyNonSequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .FirstOrDefault(e => e.Id == nonSequentialGuidKey)));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, singleRecordSelectWarmUpCount,
                    c => c.AutoIncrementIntKeyParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .FirstOrDefault(e => e.Id == autoIncrementKey));
                Console.WriteLine("Selecting {0} records...", singleRecordSelectCount);
                Console.WriteLine("Selecting records by auto-increment primary key took {0} ms",
                    BenchmarkSelect(dataContext, singleRecordSelectCount,
                        c => c.AutoIncrementIntKeyParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .FirstOrDefault(e => e.Id == autoIncrementKey)));

                //Benchmarking selecting single records (with all child collections)
                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, singleRecordSelectWarmUpCount,
                    c => c.GuidKeySequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .Include(e => e.Children2)
                        .Include(e => e.Children3)
                        .Include(e => e.Children4)
                        .Include(e => e.Children5)
                        .FirstOrDefault(e => e.Id == sequentialGuidKey));
                Console.WriteLine("Selecting {0} records...", singleRecordSelectCount);
                Console.WriteLine("Selecting records (all children) by sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, singleRecordSelectCount,
                        c => c.GuidKeySequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .Include(e => e.Children2)
                            .Include(e => e.Children3)
                            .Include(e => e.Children4)
                            .Include(e => e.Children5)
                            .FirstOrDefault(e => e.Id == sequentialGuidKey)));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, singleRecordSelectWarmUpCount,
                    c => c.GuidKeyNonSequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .Include(e => e.Children2)
                        .Include(e => e.Children3)
                        .Include(e => e.Children4)
                        .Include(e => e.Children5)
                        .FirstOrDefault(e => e.Id == nonSequentialGuidKey));
                Console.WriteLine("Selecting {0} records...", singleRecordSelectCount);
                Console.WriteLine("Selecting records (all children) by non-sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, singleRecordSelectCount,
                        c => c.GuidKeyNonSequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .Include(e => e.Children2)
                            .Include(e => e.Children3)
                            .Include(e => e.Children4)
                            .Include(e => e.Children5)
                            .FirstOrDefault(e => e.Id == nonSequentialGuidKey)));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, singleRecordSelectWarmUpCount,
                    c => c.AutoIncrementIntKeyParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .Include(e => e.Children2)
                        .Include(e => e.Children3)
                        .Include(e => e.Children4)
                        .Include(e => e.Children5)
                        .FirstOrDefault(e => e.Id == autoIncrementKey));
                Console.WriteLine("Selecting {0} records...", singleRecordSelectCount);
                Console.WriteLine("Selecting records (all children) by auto-increment primary key took {0} ms",
                    BenchmarkSelect(dataContext, singleRecordSelectCount,
                        c => c.AutoIncrementIntKeyParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .Include(e => e.Children2)
                            .Include(e => e.Children3)
                            .Include(e => e.Children4)
                            .Include(e => e.Children5)
                            .FirstOrDefault(e => e.Id == autoIncrementKey)));

                //Benchmarking joining 1000 records in one select (with child collection)
                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.GuidKeySequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .OrderBy(e => e.Id)
                        .Take(1000)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectCount);
                Console.WriteLine("Selecting 1000-record sets with sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectCount,
                        c => c.GuidKeySequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .OrderBy(e => e.Id)
                            .Take(1000)
                            .ToList()));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.GuidKeyNonSequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .OrderBy(e => e.Id)
                        .Take(1000)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectCount);
                Console.WriteLine("Selecting 1000-record sets with non-sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectCount,
                        c => c.GuidKeyNonSequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .OrderBy(e => e.Id)
                            .Take(1000)
                            .ToList()));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.AutoIncrementIntKeyParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .OrderBy(e => e.Id)
                        .Take(1000)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectCount);
                Console.WriteLine("Selecting 1000-record sets with auto-increment primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectCount,
                        c => c.AutoIncrementIntKeyParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .OrderBy(e => e.Id)
                            .Take(1000)
                            .ToList()));

                //Benchmarking joining 1000 records in one select (with all child collections)
                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.GuidKeySequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .Include(e => e.Children2)
                        .Include(e => e.Children3)
                        .Include(e => e.Children4)
                        .Include(e => e.Children5)
                        .OrderBy(e => e.Id)
                        .Take(1000)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectCount);
                Console.WriteLine("Selecting 1000-record (all children) sets with sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectCount,
                        c => c.GuidKeySequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .Include(e => e.Children2)
                            .Include(e => e.Children3)
                            .Include(e => e.Children4)
                            .Include(e => e.Children5)
                            .OrderBy(e => e.Id)
                            .Take(1000)
                            .ToList()));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.GuidKeyNonSequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .Include(e => e.Children2)
                        .Include(e => e.Children3)
                        .Include(e => e.Children4)
                        .Include(e => e.Children5)
                        .OrderBy(e => e.Id)
                        .Take(1000)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectCount);
                Console.WriteLine("Selecting 1000-record sets (all children) with non-sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectCount,
                        c => c.GuidKeyNonSequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .Include(e => e.Children2)
                            .Include(e => e.Children3)
                            .Include(e => e.Children4)
                            .Include(e => e.Children5)
                            .OrderBy(e => e.Id)
                            .Take(1000)
                            .ToList()));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.AutoIncrementIntKeyParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .Include(e => e.Children2)
                        .Include(e => e.Children3)
                        .Include(e => e.Children4)
                        .Include(e => e.Children5)
                        .OrderBy(e => e.Id)
                        .Take(1000)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectCount);
                Console.WriteLine("Selecting 1000-record sets (all children) with auto-increment primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectCount,
                        c => c.AutoIncrementIntKeyParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .Include(e => e.Children2)
                            .Include(e => e.Children3)
                            .Include(e => e.Children4)
                            .Include(e => e.Children5)
                            .OrderBy(e => e.Id)
                            .Take(1000)
                            .ToList()));

                //Benchmarking joining all records in one select (with child collection)
                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.GuidKeySequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectAllCount);
                Console.WriteLine("Selecting all records with sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectAllCount,
                        c => c.GuidKeySequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .ToList()));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.GuidKeyNonSequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectAllCount);
                Console.WriteLine("Selecting all records with non-sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectAllCount,
                        c => c.GuidKeyNonSequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .ToList()));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.AutoIncrementIntKeyParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectAllCount);
                Console.WriteLine("Selecting all records with auto-increment primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectAllCount,
                        c => c.AutoIncrementIntKeyParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .ToList()));

                //Benchmarking joining all records in one select (with all child collections)
                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.GuidKeySequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .Include(e => e.Children2)
                        .Include(e => e.Children3)
                        .Include(e => e.Children4)
                        .Include(e => e.Children5)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectAllCount);
                Console.WriteLine("Selecting all records (all children) with sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectAllCount,
                        c => c.GuidKeySequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .Include(e => e.Children2)
                            .Include(e => e.Children3)
                            .Include(e => e.Children4)
                            .Include(e => e.Children5)
                            .ToList()));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.GuidKeyNonSequentialParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .Include(e => e.Children2)
                        .Include(e => e.Children3)
                        .Include(e => e.Children4)
                        .Include(e => e.Children5)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectAllCount);
                Console.WriteLine("Selecting all records (all children) with non-sequential GUID primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectAllCount,
                        c => c.GuidKeyNonSequentialParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .Include(e => e.Children2)
                            .Include(e => e.Children3)
                            .Include(e => e.Children4)
                            .Include(e => e.Children5)
                            .ToList()));

                Console.WriteLine("Warming up...");
                BenchmarkSelect(dataContext, joinSelectWarmUpCount,
                    c => c.AutoIncrementIntKeyParentEntities
                        .AsNoTracking()
                        .Include(e => e.Children1)
                        .Include(e => e.Children2)
                        .Include(e => e.Children3)
                        .Include(e => e.Children4)
                        .Include(e => e.Children5)
                        .ToList());
                Console.WriteLine("Selecting {0} recordsets...", joinSelectAllCount);
                Console.WriteLine("Selecting all records (all children) with auto-increment primary key took {0} ms",
                    BenchmarkSelect(dataContext, joinSelectAllCount,
                        c => c.AutoIncrementIntKeyParentEntities
                            .AsNoTracking()
                            .Include(e => e.Children1)
                            .Include(e => e.Children2)
                            .Include(e => e.Children3)
                            .Include(e => e.Children4)
                            .Include(e => e.Children5)
                            .ToList()));
            }
        }

        private static long BenchmarkSelect(EntityDataContext dataContext, int count,
            Action<EntityDataContext> contextAction)
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < count; i++)
            {
                contextAction(dataContext);
            }

            sw.Stop();

            //An attempt to make garbage collection not impact benchmarking process )
            GC.Collect();
            Thread.Sleep(2000);

            return sw.ElapsedMilliseconds;
        }

        private static long BenchmarkInsert(int count,
            Action<EntityDataContext> contextAction)
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < count; i++)
            {
                using (var dataContext = new EntityDataContext())
                {
                    dataContext.Configuration.AutoDetectChangesEnabled = false;

                    contextAction(dataContext);

                    dataContext.SaveChanges();
                }
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private static long BenchmarkDbGeneratedSequentialGuid(int count, int stringLength)
        {
            return BenchmarkInsert(count,
                dc =>
                {
                    dc.GuidKeyDbSequentialEntities.Add(new GuidKeyDbSequentialEntity
                    {
                        Name = new String('A', stringLength),
                        Count = 1234
                    });
                });
        }

        private static long BenchmarkDbGeneratedNonSequentialGuid(int count, int stringLength)
        {
            return BenchmarkInsert(count,
                dc =>
                {
                    dc.GuidKeyDbNonSequentialEntities.Add(new GuidKeyDbNonSequentialEntity
                    {
                        Name = new String('A', stringLength),
                        Count = 1234
                    });
                });
        }

        private static long BenchmarkClientGeneratedNonSequentialGuid(int count, int stringLength)
        {
            return BenchmarkInsert(count,
                dc =>
                {
                    dc.GuidKeyClientNonSequentialEntities.Add(new GuidKeyClientNonSequentialEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = new String('A', stringLength),
                        Count = 1234
                    });
                });
        }

        private static long BenchmarkClientGeneratedSequentialGuid(int count, int stringLength)
        {
            return BenchmarkInsert(count,
                dc =>
                {
                    dc.GuidKeyClientSequentialEntities.Add(new GuidKeyClientSequentialEntity
                    {
                        Id = SequentialGuidUtils.CreateGuid(),
                        Name = new String('A', stringLength),
                        Count = 1234
                    });
                });
        }

        private static long BenchmarkAutoIncrementInt(int count, int stringLength)
        {
            return BenchmarkInsert(count,
                dc =>
                {
                    dc.AutoIncrementIntKeyEntities.Add(new AutoIncrementIntKeyEntity
                    {
                        Name = new String('A', stringLength),
                        Count = 1234
                    });
                });
        }
    }
}
