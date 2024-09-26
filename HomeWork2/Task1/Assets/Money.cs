using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2.Task1
{
    //Класс Money є композицією двох класів MoneyAmount та Currency
    //Наслідує абстрактний класс AssetModel(модель активу, або модель цінності) та реалізує інтерфейс IManageAssetsLike,
    //який керує кількістю цінності

    internal class Money: AssetModel, IManageAssetsLike<MoneyAmount>
    {
            protected MoneyAmount _moneyAmount;
            protected Currency _currency;

            public Money(Currency currency, decimal moneyValue)
            {
                _moneyAmount = new MoneyAmount(moneyValue);
                _currency = currency;
            }

            public override Currency Currency { get => _currency; init => _currency = value; }
            public override MoneyAmount Amount { get => _moneyAmount; set => _moneyAmount = value; }

            public override MoneyAmount Add(decimal valueToAdd)
            {
                return _moneyAmount += new MoneyAmount(valueToAdd);
            }

            public override MoneyAmount Subtract(decimal valueToSubtract)
            {
                return _moneyAmount -= new MoneyAmount(valueToSubtract);
            }

            public override MoneyAmount CalculatePrecentage(int percentage)
            {
                return Amount.GetPrecentageOfAmount(percentage);
            }

    }
}
