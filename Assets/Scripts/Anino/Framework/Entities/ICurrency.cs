namespace Anino.Framework
{
    public interface ICurrency
    {
        long amount {get;}
        void AddCurrency(long amount);
        void RemoveCurrency(long amount);
    }
}