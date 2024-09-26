using HomeWork2.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2.Task1
{
    public class Service : TradableModel<AssetModel>
    {
        public override int Id { get; init; }

        public override AssetModel Price { get; protected set; }

        public Service(int id, string name, string description, AssetModel price)
        {

            Id = id;
            Name = name;
            Description = description;
            Price = price;

        }

        public override string ToString()
        {
            return $"Service: {Name}, \n{Description}, \nPrice: {Price.Amount} {Price.Currency}";
        }
    }
}
