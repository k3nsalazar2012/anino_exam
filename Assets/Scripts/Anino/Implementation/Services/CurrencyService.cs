using System.Collections.Generic;
using Anino.Framework;

namespace Anino.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        public ICurrency currency => _currency;
        private ICurrency _currency;
        private List<ICurrencySubscriber> _subscriptions = new List<ICurrencySubscriber>();
        
        public long betAmount => _betAmount;
        private long _betAmount;

        public void SetCurrency(ICurrency currency)
        {
            _currency = currency;
            NotifySubscribers();
        } 

        public void AddCurrency(long amount)
        {
            _currency.AddCurrency(amount);
            NotifySubscribers();
        }

        public void RemoveCurrency(long amount)
        {
            AddCurrency(-amount);
        }

        public void Subscribe(ICurrencySubscriber subscriber)
        {
            if(!_subscriptions.Contains(subscriber))
                _subscriptions.Add(subscriber);
        }

        public void Unsubscribe(ICurrencySubscriber subscriber)
        {
            if(_subscriptions.Contains(subscriber))
                _subscriptions.Remove(subscriber);
        }

        private void NotifySubscribers()
        {
            foreach(var subscriber in _subscriptions)
            {
                subscriber?.OnCurrencyUpdated(_currency.amount);
            }
        }

        public void SetBet(long amount)
        {
            _betAmount = amount;
        }
    }
}