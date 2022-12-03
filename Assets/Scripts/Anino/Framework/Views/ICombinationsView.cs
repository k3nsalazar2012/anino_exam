using System.Collections.Generic;

namespace Anino.Framework
{
    public interface ICombinationsView
    {
        ICombinationsController controller {get;}
        void ShowCombinations(List<List<int>> combinations);
    }
}