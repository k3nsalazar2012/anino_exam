using System;

namespace Anino.Framework
{
    public interface ICurrencySubscriber
    {
        void OnCurrencyUpdated(long amount);
    }
}