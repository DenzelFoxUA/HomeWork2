using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace HomeWork2.Task1
{

    //Класс MoneyAmount відповідає за збереження інформації стосовно кількості цінності і операції
    // з нею за допомогою перевантажених операторів.
    //Наслідує абстрактний класс AssetAmount(кількість активу, або кількість цінності)

    public class MoneyAmount : AssetAmount
    {

        //константи для форматування і збереження грошей
        private const int SMALL_CHANGE_LOW_LIMIT = 0;
        private const int SMALL_CHANGE_UPPER_LIMIT = 99;
        private const int SMALL_CHANGE_AMOUNT_IN_A_WHOLE = 100;

        protected override int SmallChange
        {
            get => _smallChange;

            set
            {
                if (value >= SMALL_CHANGE_LOW_LIMIT && value <= SMALL_CHANGE_UPPER_LIMIT)
                {
                    _smallChange = value;
                }
            }
        }

        protected override int WholeUnits { get; set; }

        public MoneyAmount()
        {
            WholeUnits = 0;
            SmallChange = 0;
        }

        public MoneyAmount(decimal value)
        {
            WholeUnits = (int)Math.Floor(value);
            SmallChange = (int)Math.Floor((value - WholeUnits) * SMALL_CHANGE_AMOUNT_IN_A_WHOLE);
        }

        public MoneyAmount(string textValueOfMoneyAmount)
        {

            int[] amountValueParts = new[] { 0, 0 };

            try
            {
                amountValueParts = GetValueFromString(textValueOfMoneyAmount);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                WholeUnits = amountValueParts[0];
                SmallChange = amountValueParts[1];
            }

        }

        public static MoneyAmount operator +(MoneyAmount amountOne, MoneyAmount amountTwo)
        {
            decimal result = amountOne.GetValueInDecimal() + amountTwo.GetValueInDecimal();
            return new(result);
        }

        public static MoneyAmount operator -(MoneyAmount amountOne, MoneyAmount amountTwo)
        {
            decimal result = amountOne.GetValueInDecimal() - amountTwo.GetValueInDecimal();
            return new(result);
        }

        public static bool operator ==(MoneyAmount amountOne, MoneyAmount amountTwo)
        {
            return amountOne.GetValueInDecimal() == amountTwo.GetValueInDecimal();

        }

        public static bool operator !=(MoneyAmount amountOne, MoneyAmount amountTwo)
        {

            return !(amountOne == amountTwo);

        }

        public override decimal GetValueInDecimal()
        {
            return WholeUnits + SmallChange / (decimal)SMALL_CHANGE_AMOUNT_IN_A_WHOLE;
        }

        public override MoneyAmount GetPrecentageOfAmount(int percents)
        {
            decimal result = 0;
            int numberOfDigitsAfterComma = 2;

            if (percents > 0 && percents < 100)
            {
                result = Math.Round(this.GetValueInDecimal() / 100 * percents, numberOfDigitsAfterComma);
                return new(result);
            }
            else
            {
                throw new ArgumentException("%Value must be from 0 to 100");
            }

        }

        protected override int[] GetValueFromString(string textValue)
        {
            char spliter = ',';

            int _wholePart = 0,
                _smallChange = 0;

            int inAHalf = 2;

            if (isThereOneSplitter(textValue, spliter) == true)
            {
                string[] textSplited = textValue.Split(spliter, inAHalf);
                string croppedSmallChange = textSplited[1].ElementAt(0).ToString() +
                                            textSplited[1].ElementAt(1).ToString() +
                                            textSplited[1].ElementAt(2).ToString();

                int.TryParse(textSplited[0], out _wholePart);
                int.TryParse(croppedSmallChange, out _smallChange);

                _smallChange = (int)Math.Round(_smallChange / 10M);

                return new[] { _wholePart, _smallChange };
            }
            else
            {
                throw new ArgumentException("Wrong text value.");
            }

        }

        private static bool isThereOneSplitter(string textValue, char splitter)
        {
            if (textValue is not null)
            {
                int number = textValue.Count(_symbol => _symbol == splitter);
                return number == 1 ? true : false;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object ?obj)
        {
            if (obj is not MoneyAmount || obj is null) return false;

            MoneyAmount other = (MoneyAmount)obj;

            return SmallChange == other.SmallChange && WholeUnits == other.WholeUnits;
        }

        public override int GetHashCode()
        {
            return this.GetValueInDecimal().GetHashCode();
        }

        public override string ToString()
        {
            string smallChangeFormated = string.Empty;

            if (SmallChange >= 0 && SmallChange <= 9)
            {
                smallChangeFormated = "0" + SmallChange.ToString();
            }
            else
            {
                smallChangeFormated = SmallChange.ToString();
            }
            return $"{WholeUnits},{smallChangeFormated}";
        }
    }

}
