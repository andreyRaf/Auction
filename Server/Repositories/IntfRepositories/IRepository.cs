using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface IRepository<Domain, View>
        where View : Domain
        where Domain : class
    {
        IQueryable<View> Get(Expression<Func<Domain, bool>> filter = null);

        Domain Save(Domain objectToSave);

        void Delete(Domain objectToDelete);

        IQueryable<View> Extend(IQueryable<Domain> dom);
    }

    public interface IRepository<Domain> : IRepository<Domain, Domain>
        where Domain : class { }
}
