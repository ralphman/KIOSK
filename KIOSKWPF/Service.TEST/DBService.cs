using KIOSKWPF.Service.IF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF.Service.TEST
{
    internal class DBService : IDBService
    {
        protected INWService Network { get; }

        public DBService(INWService network)
        {
            Network = network;
        }

        public void LoadDB()
        {
            throw new NotImplementedException();
        }
    }
}
