namespace Anino.Framework
{
    public interface ICurrency
    {
        long amount {get;}
        void SetAmount(long amount);
        void AddCurrency(long amount);
        void RemoveCurrency(long amount);
    }
}