namespace Anino.Framework
{
    public interface ICurrencyController
    {
        void SetView(ICurrencyView view);
        void SetCurrencyAmount(long amount);
    }
}