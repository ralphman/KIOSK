using KIOSKWPF.Service.IF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF.Service.TEST
{
    internal class DBService : IDBService
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
            string directory = System.AppDomain.CurrentDomain.BaseDirectory;

            // DB에서 데이터를 읽어오는 용도로 하면 된다.
            var hamburgers = new List<MenuItem>()
            {
                new Hamburger() { Name = "불고기버거", Price = 5000, ImagePath=Path.Combine(directory, @"Image/Food/hamburger_1.png") },
                new Hamburger() { Name = "새우버거", Price = 7000, ImagePath=Path.Combine(directory, @"Image/Food/hamburger_2.png") },
                new Hamburger() { Name = "오징어버거", Price = 6500, ImagePath=Path.Combine(directory, @"Image/Food/hamburger_3.png") },
            };

            var beverages = new List<MenuItem>()
            {
                new Beverage() { Name = "콜라", Price = 1000, ImagePath=Path.Combine(directory, @"Image/Food/beverage_1.png") },
                new Beverage() { Name = "사이다", Price = 1000, ImagePath=Path.Combine(directory, @"Image/Food/beverage_2.png") },
                new Beverage() { Name = "오렌지주스", Price = 2500, ImagePath=Path.Combine(directory, @"Image/Food/beverage_3.png") },
            };

            var deserts = new List<MenuItem>()
            {
                new Desert() { Name = "아이스크림", Price = 2000, ImagePath=Path.Combine(directory, @"Image/Food/desert_1.png") },
                new Desert() { Name = "마카롱", Price = 3000, ImagePath=Path.Combine(directory, @"Image/Food/desert_2.png") },
            };

            MenuItems.Add(enCategory.Hamburger, hamburgers);
            MenuItems.Add(enCategory.Beverage, beverages);
            MenuItems.Add(enCategory.Desert, deserts);

            return true;
        }
    }
}
