namespace HomeWork2.Task1
{
    //Абстрактний класс AssetAmount(кількість активу, або кількість цінності)
    //створений для того щоб вподальшому можна було додавати інщі види цінностей та управління ними (не тільки гроші)
    public abstract class AssetAmount
    {

        protected int _wholeUnits;
        protected int _smallChange;
        protected abstract int WholeUnits { get; set; }
        protected abstract int SmallChange { get; set; }

        public abstract decimal GetValueInDecimal();

        public abstract AssetAmount GetPrecentageOfAmount(int percents);

        protected abstract int[] GetValueFromString(string textValue);

    }

}
