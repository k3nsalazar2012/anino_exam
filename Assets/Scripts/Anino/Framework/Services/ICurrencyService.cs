namespace Anino.Framework
{
    public interface ICurrencyService
    {
        ICurrency currency {get;}
        long betAmount {get;}
        
        void SetCurrency(ICurrency currency);
        void AddCurrency(long amount);
        void RemoveCurrency(long amount);
        void Subscribe(ICurrencySubscriber subscriber);
        void Unsubscribe(ICurrencySubscriber subscriber);
        void SetBet(long amount);
    }
}