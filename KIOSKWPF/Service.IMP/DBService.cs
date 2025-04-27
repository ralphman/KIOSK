using KIOSKWPF.Service.IF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF.Service.IMP
{
    internal class DBService
    {
        public Dictionary<enCategory, List<MenuItem>> MenuItems { get; protected set; }

        protected INWService Network { get; }

        public DBService(INWService network)
        {
            Network = network;

            MenuItems = new Dictionary<enCategory, List<MenuItem>>();
        }

        public bool LoadMenuData()
        {
            return true;
        }
    }
}
