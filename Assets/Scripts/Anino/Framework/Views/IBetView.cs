namespace Anino.Framework
{
    public interface IBetView
    {
        IBetController controller {get;}

        void UpdateBet(long amount);
    }
}