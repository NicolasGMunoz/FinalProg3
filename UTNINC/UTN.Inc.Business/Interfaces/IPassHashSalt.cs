using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Inc.Business.Interfaces
{
    public interface IPassHashSalt
    {
        void CrearPassHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifPassHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}
