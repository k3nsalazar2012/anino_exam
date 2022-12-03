using System.Collections.Generic;
using Anino.Framework;
using System.Linq;

namespace Anino.Implementation
{
    public class PayoutService : IPayoutService
    {
        const int REELS_COUNT = 5;

        private List<List<int>> _payoutLines;
        private List<int> _singleDimensionSpinResults;
        private IEnumerable<IGrouping<int, int>> _validGroupsBySymbol;
        private int _payoutLinesHitCount;
        private bool _hasPayout;

        public void SetPayoutLines(List<List<int>> payoutLines)
        {
            _payoutLines = payoutLines;
        }

        public void SetResults(List<List<int>> spinResults)
        {
            _singleDimensionSpinResults = new List<int>();
            for(int j=0; j<3; j++)
            {
                for(int i=0; i<spinResults.Count; i++)
                {
                    _singleDimensionSpinResults.Add(spinResults[i][j]);
                }
            }

            _validGroupsBySymbol = _singleDimensionSpinResults.GroupBy(v => v).Where(v => v.Count() == REELS_COUNT);
            
            CalculatePayoutLines();
        }

        public void CalculatePayoutLines()
        {
            _payoutLinesHitCount = 0;

            foreach(var group in _validGroupsBySymbol)
            {
                List<int> _singleValueResults = new List<int>();

                foreach(var result in _singleDimensionSpinResults)
                {
                    _singleValueResults.Add(result == group.Key ? 1 : 0);
                }

                foreach(var lines in _payoutLines)
                {
                    if(Enumerable.SequenceEqual(lines, _singleValueResults))
                        _payoutLinesHitCount++;                        
                }
            }

            _hasPayout = _payoutLinesHitCount != 0;
        }

        public bool HasPayout()
        { 
            return _hasPayout;
        }

        public int GetPayoutLinesHitCount()
        {
            return _payoutLinesHitCount;
        }
    }
}