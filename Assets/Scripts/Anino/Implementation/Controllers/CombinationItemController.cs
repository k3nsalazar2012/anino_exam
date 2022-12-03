using System.Collections.Generic;
using Anino.Framework;

namespace Anino.Implementation
{
    public class CombinationItemController : ICombinationItemController
    {
        private ICombinationItemView _view;
        private List<int> _data;

        public void SetData(List<int> data)
        {
            _data = data;
            ProcessData();
        }

        public void SetView(ICombinationItemView view)
        {
            _view = view;
        }

        private void ProcessData()
        {
            foreach(var value in _data)
            {
                if(value == 1)
                    _view.AddMarkedCell();
                else
                    _view.AddBlankCell();
            }
            _view.UpdateLineText();
        }
    }
}