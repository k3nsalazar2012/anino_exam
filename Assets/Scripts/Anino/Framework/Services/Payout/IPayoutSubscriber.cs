namespace Anino.Framework
{
    public interface IPayoutSubscriber
    {
        void OnWin(int payoutLinesCount);
    }
}