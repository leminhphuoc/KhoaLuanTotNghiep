using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
{
    public interface IIPAddressRepository
    {
        bool AddIpAddress(string IpAddress);
    }
}
