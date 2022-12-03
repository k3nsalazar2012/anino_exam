using System.Collections.Generic;

namespace Anino.Framework
{
    public interface IPayoutLineData
    {
        RowData[] rows {get;}
        List<int> GetDataAsSingleArray();
    }

    [System.Serializable]
    public struct RowData
    {
        public int[] row;
    }
}