namespace Anino.Framework
{
    public interface ICurrencyView 
    {
        ICurrencyController controller {get;}
        void UpdateCurrencyText(long amount);
    }
}