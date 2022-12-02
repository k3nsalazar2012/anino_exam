using System;
using UnityEngine;

namespace Anino.Implementation
{
    [Serializable]
    public class PayoutLineData
    {
        [Serializable]
        public struct RowData
        {
            public int[] row;
        }
        
        [SerializeField]
        public RowData[] rows = new RowData[3];
    }
}