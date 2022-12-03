using System.Collections.Generic;

namespace Anino.Framework
{
    public interface ICombinationItemController
    {
        void SetView(ICombinationItemView view);
        void SetData(List<int> data);
    }
}