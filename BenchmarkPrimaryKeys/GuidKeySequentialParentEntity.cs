using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenchmarkPrimaryKeys
{
    public class GuidKeySequentialParentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(4000)]
        public string Name { get; set; }

        public List<GuidKeySequentialChildEntity1> Children1 { get; set; }

        public List<GuidKeySequentialChildEntity2> Children2 { get; set; }

        public List<GuidKeySequentialChildEntity3> Children3 { get; set; }

        public List<GuidKeySequentialChildEntity4> Children4 { get; set; }

        public List<GuidKeySequentialChildEntity5> Children5 { get; set; }
    }
}
