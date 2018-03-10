using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : 
            base("TreeViewConnection")
        {
            Database.SetInitializer<DbContext>(null);
        }

        public DbSet<Category> Categories { get; set; }
    }
}
