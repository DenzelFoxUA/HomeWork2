using System.Runtime.InteropServices;

namespace HomeWork2.Task1
{
    //клас валюта створений для збереження даних про валюту в якій проводиться операція
    //має перевантажені оператори порівнняння для того, щоб при додаванні нових валют до загального списку не виникало дублікатів
    //є складовою частиною композиції грошей
    public class Currency
    {
        public int CurrencyId { get; init; }

        public string CurrencyName { get; init; }

        public string CurrencyCode { get; init; }

        private Currency()
        {
            CurrencyId = 0;
            CurrencyName = "Currency";
            CurrencyCode = "DEFAULT";
        }

        public Currency(int id, string name, string code)
        {
            CurrencyId = id;
            CurrencyName = name;
            CurrencyCode = code;
        }

        public static bool operator == (Currency leftValue, Currency rightValue)
        {
            return leftValue.CurrencyId == rightValue.CurrencyId &&
                   leftValue.CurrencyCode == rightValue.CurrencyCode;
        }

        public static bool operator !=(Currency leftValue, Currency rightValue)
        {
            return !(leftValue.CurrencyCode == rightValue.CurrencyCode);
        }

        public override string ToString()
        {
            return $"{CurrencyCode}";
        }

        public override bool Equals(object ?obj)
        {
            if(obj is not null)
            {
                var other = (Currency)obj;

                return CurrencyId == other.CurrencyId && CurrencyName == other.CurrencyName;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (CurrencyId + CurrencyCode).GetHashCode();
        }
    }
}
