using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenchmarkPrimaryKeys
{
    public class GuidKeyNonSequentialParentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(4000)]
        public string Name { get; set; }

        public List<GuidKeyNonSequentialChildEntity1> Children1 { get; set; }

        public List<GuidKeyNonSequentialChildEntity2> Children2 { get; set; }

        public List<GuidKeyNonSequentialChildEntity3> Children3 { get; set; }

        public List<GuidKeyNonSequentialChildEntity4> Children4 { get; set; }

        public List<GuidKeyNonSequentialChildEntity5> Children5 { get; set; }
    }
}
