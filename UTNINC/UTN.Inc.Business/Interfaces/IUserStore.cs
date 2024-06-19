using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Inc.Data.DBContext;
using UTN.Inc.Entities;

namespace UTN.Inc.Business.Interfaces
{
    public interface IUserStore
    {

        void RegistrarUsuario(string username, string password);

    }
}
