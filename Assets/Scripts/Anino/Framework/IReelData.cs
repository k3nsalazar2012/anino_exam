using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Anino.Framework
{
    public interface IReelData 
    {
        Vector2 symbolResolution {get;}
        Sprite[] symbols {get;}
        int symbolsCount {get;}

        float GetVerticalSpacing();
        float GetEndPosition();
    }
}