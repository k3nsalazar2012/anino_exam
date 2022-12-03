using System.Collections.Generic;

namespace Anino.Framework
{
    public interface IPayoutService
    {
        void SetResults(List<List<int>> spinResults);
        void SetPayoutLines(List<List<int>> payoutLines);
        void CalculatePayoutLines();
        bool HasPayout();   
        int GetPayoutLinesHitCount();
    }
}