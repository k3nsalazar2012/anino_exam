namespace Anino.Framework
{
    public interface IBetController
    {
        long betAmount {get;}

        void SetView(IBetView view);
        
        void IncreaseBet();
        void DecreaseBet();
    }
}