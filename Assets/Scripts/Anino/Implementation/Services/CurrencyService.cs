using Anino.Framework;

namespace Anino.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        public ICurrency currency => _currency;
        private ICurrency _currency;

        public void SetCurrency(ICurrency currency)
        {
            _currency = currency;
        } 

        public void AddCurrency(long amount)
        {
            _currency.AddCurrency(amount);
        }

        public void RemoveCurrency(long amount)
        {
            _currency.AddCurrency(-amount);
        }
    }
}