using System.Collections.Generic;
using Anino.Framework;

namespace Anino.Implementation
{
    public class CombinationsController : ICombinationsController
    {
        private ICombinationsView _view;
        private IPayoutLineData[] _data;
        public void SetView(ICombinationsView view)
        {
            _view = view;
        }

        public void SetData(IPayoutLineData[] data)
        {
            _data = data;
            ProcessData();
        }

        private void ProcessData()
        {
            var combinations = new List<List<int>>();
            
            foreach(var payoutLineData in _data)
            {
                combinations.Add(payoutLineData.GetDataAsSingleArray());
            }
            
            _view.ShowCombinations(combinations);
        }
    }
}