using Anino.Framework;

namespace Anino.Implementation
{
    public class CurrencyController : ICurrencyController
    {
        private ICurrencyView _view;

        public void SetView(ICurrencyView view)
        {
            _view = view;
        }

        public void SetCurrencyAmount(long amount)
        {
            _view.UpdateCurrencyText(amount);
        }
    }
}