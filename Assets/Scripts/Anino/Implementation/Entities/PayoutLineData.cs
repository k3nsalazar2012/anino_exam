using System;
using System.Collections.Generic;
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
        
        public List<int> GetDataAsSingleArray()
        {
            List<int> _singleArrayData = new List<int>();
            for(int j=0; j<rows.Length; j++)
            {
                for(int i=0; i<rows[j].row.Length; i++)
                {
                    _singleArrayData.Add(rows[j].row[i]);
                }
            }
            return _singleArrayData;
        }
    }
}