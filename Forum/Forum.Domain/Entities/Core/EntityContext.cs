using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Entities.Core
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("ForumEntities") { }
        
        public IDbSet<Person> Persons { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<Category> Categorys { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Post> Posts { get; set; }
        public IDbSet<View> Views { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }


}
