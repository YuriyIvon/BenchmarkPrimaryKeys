using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BenchmarkPrimaryKeys
{
    class Program
    {
        static void Main(string[] args)
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

        private static long Benchmark(int count, 
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
            return Benchmark(count,
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
            return Benchmark(count,
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
            return Benchmark(count,
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
            return Benchmark(count,
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
            return Benchmark(count,
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
