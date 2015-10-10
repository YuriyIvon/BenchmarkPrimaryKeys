using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenchmarkPrimaryKeys
{
    public class AutoIncrementIntKeyParentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<AutoIncrementIntKeyChildEntity1> Children1 { get; set; }

        public List<AutoIncrementIntKeyChildEntity2> Children2 { get; set; }

        public List<AutoIncrementIntKeyChildEntity3> Children3 { get; set; }

        public List<AutoIncrementIntKeyChildEntity4> Children4 { get; set; }

        public List<AutoIncrementIntKeyChildEntity5> Children5 { get; set; }
    }
}
