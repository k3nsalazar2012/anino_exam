using UnityEngine;

namespace Anino.Framework
{
    public interface IReelData 
    {
        Vector2 symbolResolution {get;}
        int[] symbols {get;}
        Sprite[] symbolSprites {get;}
        int symbolsCount {get;}

        float GetVerticalSpacing();
        float GetEndPosition();
    }
}