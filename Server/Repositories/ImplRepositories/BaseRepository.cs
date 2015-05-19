using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using Server.EF;
using System.Linq.Expressions;

namespace Server
{
    public abstract class BaseRepository<Domain, View> : IRepository<Domain, View>
        where View : Domain
        where Domain : class
    {
        protected DataContext context = new DataContext();//{ get; set; }

                                            //Predicate<Domain>
        public virtual IQueryable<View> Get(Expression<Func<Domain, bool>> filter = null)
        {
            IQueryable<Domain> filtered = context.Set<Domain>();
            if (filter != null)
            {
                filtered = filtered.Where(filter);
            }
            return this.Extend(filtered);
        }

        public virtual Domain Save(Domain objectToSave)
        {
            context.Set<Domain>().AddOrUpdate(objectToSave);
            context.SaveChanges();
            return objectToSave;
        }

        public virtual void Delete(Domain objectToDelete)
        {
            context.Set<Domain>().Remove(objectToDelete);
            context.SaveChanges();
        }

        public abstract IQueryable<View> Extend(IQueryable<Domain> dom);
    }

    public abstract class BaseRepository<Domain> : BaseRepository<Domain, Domain>
        where Domain : class
    {
        public override IQueryable<Domain> Extend(IQueryable<Domain> dom)
        {
            return dom;
        }
    }
}
