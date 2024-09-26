using HomeWork2.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2.Task1
{
    //Абстрактний класс TradableModel(модель всього що має ціну)
    //створений для того щоб вподальшому можна було додавати інщі види товарів та послуг (не тільки товар)
    //також має реалізацію дженеріка Т для того, щоб можна було додавати в ціну інші цінності (не тільки гроші)
    //але тількі ті цінності, що наслідують AssetModel
    public abstract class TradableModel<T> where T : AssetModel
    {
        public const int NUMBER_OF_CHARS_IN_DESCRIPTION = 250;
        public virtual int Id { get; init; } = 0;
        public virtual string Name { get; init; } = string.Empty;

        public virtual string Description { get; protected set; } = string.Empty;

        public virtual T Price { get; protected set; }

        public virtual void SetPriceWithDiscount(int percent)
        {
            MoneyAmount priceDiscount = Price.Amount.GetPrecentageOfAmount(percent);
            Price.Amount -= priceDiscount;
        }

        public virtual void SetNewDescription(string text)
        {
            if (text is not null && text.Length <= NUMBER_OF_CHARS_IN_DESCRIPTION)
            {
                this.Description = text;
            }
        }
        public virtual void IncreasePrice(decimal value)
        {
                Price.Amount += new MoneyAmount(value);
        }

        public virtual void DecreasePrice(decimal value)
        {
            if(Price.Amount.GetValueInDecimal() >= value)
            {
                Price.Amount -= new MoneyAmount(value);
            }
            else
            {
                throw new ArgumentException("Value must be less than price");
            }
        }

        public override string ToString()
        {
            return $"Tradable: {Name} \nPrice: {Price.Amount} {Price.Currency}\n";
        }
    }
}
