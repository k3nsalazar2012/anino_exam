using System.Collections.Generic;

namespace Anino.Framework
{
    public interface ICombinationItemView
    {
        ICombinationItemController controller {get;}

        void UpdateLineText();
        void AddBlankCell();
        void AddMarkedCell();
    }
}