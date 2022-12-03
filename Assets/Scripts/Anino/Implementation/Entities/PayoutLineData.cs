using System;
using System.Collections.Generic;
using UnityEngine;
using Anino.Framework;

namespace Anino.Implementation
{
    [Serializable]
    public class PayoutLineData : IPayoutLineData
    {        
        [SerializeField]
        private RowData[] _rows = new RowData[3];
        public RowData[] rows => _rows;
        
        public List<int> GetDataAsSingleArray()
        {
            List<int> _singleArrayData = new List<int>();
            for(int j=0; j<_rows.Length; j++)
            {
                for(int i=0; i<_rows[j].row.Length; i++)
                {
                    _singleArrayData.Add(_rows[j].row[i]);
                }
            }
            return _singleArrayData;
        }
    }
}