namespace Anino.Framework
{
    public interface ICombinationsController
    {
        void SetView(ICombinationsView view);
        void SetData(IPayoutLineData[] data);
    }
}