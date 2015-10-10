using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenchmarkPrimaryKeys
{
    public class GuidKeySequentialChildEntity1
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(4000)]
        public string Name { get; set; }

        public Guid ParentId { get; set; }

        public GuidKeySequentialParentEntity Parent { get; set; }
    }
}
