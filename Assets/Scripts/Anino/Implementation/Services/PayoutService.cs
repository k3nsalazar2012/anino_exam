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
        private List<IPayoutSubscriber> _subscriptions = new List<IPayoutSubscriber>();

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

            /*foreach(var result in _singleDimensionSpinResults)
            {
                UnityEngine.Debug.Log($"[result] {result}");
            }*/

            _validGroupsBySymbol = _singleDimensionSpinResults.GroupBy(v => v).Where(v => v.Count() >= REELS_COUNT);
            
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
                    CheckLineAndResults(lines, _singleValueResults);                    
                }
            }

            _hasPayout = _payoutLinesHitCount != 0;
            
            if(_hasPayout)
                NotifySubscribers();
        }

        public bool HasPayout()
        { 
            return _hasPayout;
        }

        public int GetPayoutLinesHitCount()
        {
            return _payoutLinesHitCount;
        }

        private void CheckLineAndResults(List<int> lines, List<int> results)
        {
            int matchCount = 0;

            for(int i=0; i<lines.Count; i++)
            {
                if(lines[i]==1 && (lines[i] == results[i]))
                {
                    matchCount++;
                }
            }

            if(matchCount == REELS_COUNT)
                _payoutLinesHitCount++;
        }

        public void Subscribe(IPayoutSubscriber subscriber)
        {
            if(!_subscriptions.Contains(subscriber))
                _subscriptions.Add(subscriber);
        }

        public void Unsubscriber(IPayoutSubscriber subscriber)
        {
            if(_subscriptions.Contains(subscriber))
                _subscriptions.Remove(subscriber);
        }

        public void NotifySubscribers()
        {
            foreach(var subscriber in _subscriptions)
            {
                subscriber?.OnWin(_payoutLinesHitCount);
            }
        }
    }
}