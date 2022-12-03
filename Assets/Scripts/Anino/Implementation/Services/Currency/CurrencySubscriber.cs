using Anino.Framework;

namespace Anino.Implementation
{
    public class CurrencySubscriber : ICurrencySubscriber
    {
        public long currencyAmount => _currencyAmount;
        private long _currencyAmount;

        public void OnCurrencyUpdated(long amount)
        {
            _currencyAmount = amount;
        }
    }
}