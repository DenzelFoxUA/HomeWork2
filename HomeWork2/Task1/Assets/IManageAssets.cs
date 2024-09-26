using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2.Task1
{
    public interface IManageAssetsLike<T>
    {
        public T Add(decimal valueToAdd);

        public T Subtract(decimal valueToSubtract);

        public T CalculatePrecentage(int percentage);
    }
}
