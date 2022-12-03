using Anino.Framework;
using UnityEngine;

namespace Anino.Implementation
{
    public class Currency : ICurrency
    {
        [SerializeField] private long _amount;
        public long amount => _amount;

        public Currency(long amount)
        {
            _amount = amount;
        }

        public void AddCurrency(long amount)
        {
            _amount+=amount;
        }

        public void RemoveCurrency(long amount)
        {
            if(amount > _amount)
            {
                UnityEngine.Debug.Log($"will result in negative currency, handle exception");
                return;
            }

            AddCurrency(-amount);
        }
    }
}