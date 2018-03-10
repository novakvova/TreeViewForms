using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Entities
{
    [Table("tblCategories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength:255)]
        public string Name { get; set; }
        [ForeignKey("Parent")]
        public int ? ParentId { get; set; }
        public Category Parent { get; set; }
    }
}
