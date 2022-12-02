using Anino.Framework;
using UnityEngine;
using System;

namespace Anino.Implementation
{
    [Serializable]
    public class ReelData : IReelData
    {
        [SerializeField] private Vector2 _symbolResolution;
        public Vector2 symbolResolution => _symbolResolution;
        
        [SerializeField] private int[] _symbols;
        public int[] symbols => _symbols;
        
        [SerializeField] private Sprite[] _symbolSprites;
        public Sprite[] symbolSprites => _symbolSprites;

        [SerializeField] private int _symbolsCount;
        public int symbolsCount => _symbolsCount;

        public float GetVerticalSpacing()
        {
            return _symbolResolution.y/100;
        }

        public float GetEndPosition()
        {
            return -_symbolsCount * GetVerticalSpacing();
        }
    }
}