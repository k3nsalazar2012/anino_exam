using System;
using System.Collections;

namespace Anino.Framework
{
    public interface IReelController
    {
        Action<float> onSpin {get; set;}
        Action<int, int, int> onSpinEnded {get;set;}
        bool isSpinning {get;}

        void SetView(IReelView view);
        void SetData(IReelData data);
        void Spin();
        void StopSpin();
        IEnumerator Spinning();
        int GetTopRowResult();
        int GetMiddleRowResult();
        int GetBottomRowResult();

        #if UNITY_EDITOR
        void SetPosition(float position);
        #endif
    }
}