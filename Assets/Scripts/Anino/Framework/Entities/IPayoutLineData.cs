namespace Anino.Framework
{
    public interface IPayoutLineData
    {
        RowData[] rows {get;}
    }

    [System.Serializable]
    public struct RowData
    {
        public int[] row;
    }
}