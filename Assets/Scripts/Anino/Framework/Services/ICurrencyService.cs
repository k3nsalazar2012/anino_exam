namespace Anino.Framework
{
    public interface ICurrencyService
    {
        ICurrency currency {get;}

        void SetCurrency(ICurrency currency);
        void AddCurrency(long amount);
        void RemoveCurrency(long amount);
    }
}