using HomeWork2.Task1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2.Task1
{
    public class Product : TradableModel<AssetModel>
    {
        public override int Id { get; init; }

        public override AssetModel Price { get; protected set; }

        public Product(int id, string name, string description, AssetModel price) 
        { 

            Id = id;
            Name = name;
            Description = description;
            Price = price;
        
        }

        public override string ToString()
        {
            return $"Product: {Name}, \n{Description}, \nPrice: {Price.Amount} {Price.Currency}";
        }

    }
}
