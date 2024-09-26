using HomeWork2.Task1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork2.Task1
{
    //Абстрактний класс AssetModel(модель активу, або модель цінності)
    //створений для того щоб вподальшому можна було додавати інщі види цінностей та управління ними (не тільки гроші)
    public abstract class AssetModel
    {
        public abstract MoneyAmount Amount { get; set; }

        public abstract Currency Currency { get; init; }

        public virtual MoneyAmount Add(decimal valueToAdd)
        {
            return Amount += new MoneyAmount(valueToAdd);
        }

        public virtual MoneyAmount Subtract(decimal valueToSubtract)
        {
            return Amount -= new MoneyAmount(valueToSubtract);
        }

        public virtual MoneyAmount CalculatePrecentage(int percentage)
        {
            return Amount.GetPrecentageOfAmount(percentage);
        }

    }
}
