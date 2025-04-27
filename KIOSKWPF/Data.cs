using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF
{
    enum enCategory
    {
        None = 0,

        Hamberger = 1,

        Beverage = 2,

        Desert = 3
    }

    internal abstract class MenuItem
    {
        public MenuItem(enCategory category)
        {
            Category = category;
        }

        public enCategory Category { get; }

        public string Code { get;set; }

        public string Name { get; set; }

        public int Price { get; set; } 

        public string ImagePath { get; set; }
    }

    internal class Hamberger : MenuItem
    {
        public Hamberger() : base(enCategory.Hamberger)
        {
        }
    }

    internal class Beverage : MenuItem
    {
        public Beverage() : base(enCategory.Beverage)
        {
        }
    }

    internal class Desert : MenuItem
    {
        public Desert() : base(enCategory.Desert)
        {
        }
    }

    internal class OrderItem : MVVMBase
    {
        public OrderItem(MenuItem item, int count = 0)
        {
            Item = item;
            Count = count;
        }

        public MenuItem Item { get; }

        public string Name => Item?.Name ?? string.Empty;

        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _count = 0;

        public int Price => Item?.Price * Count ?? 0;

        public void Add() => Count++;

        public void Delete() => Count--;
    }
}
