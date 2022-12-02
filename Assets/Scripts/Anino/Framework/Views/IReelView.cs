using UnityEngine;

namespace Anino.Framework
{
    public interface IReelView
    {
        IReelController controller {get;}
        void Initialize();
        void SetObserver(IReelViewObserver observer);
        void CreateReel();
        void OnSpin(float position);
    }

    public interface IReelViewObserver
    {
        void OnSpinInteract(MonoBehaviour mono);
        void OnStopSpinInteract();
    }
}