using System;
using System.Collections;

namespace Anino.Framework
{
    public interface IReelController
    {
        Action<float> onSpin {get;}
        bool isSpinning {get;}

        void Spin();
        void StopSpin();
        IEnumerator Spinning();
        int GetMiddleRowResult();

        #if UNITY_EDITOR
        void SetPosition(float position);
        #endif
    }
}