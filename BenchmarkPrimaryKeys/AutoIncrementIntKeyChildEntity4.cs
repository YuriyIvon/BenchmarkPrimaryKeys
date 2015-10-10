using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenchmarkPrimaryKeys
{
    public class AutoIncrementIntKeyChildEntity4
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }

        public AutoIncrementIntKeyParentEntity Parent { get; set; }
    }
}
