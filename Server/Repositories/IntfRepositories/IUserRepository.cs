using Server.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface IUserRepository : IRepository<t_user>
    {
    }
}