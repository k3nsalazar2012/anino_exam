using UnityEngine;

namespace Anino.Implementation
{
    [CreateAssetMenu(menuName = "Anino/Data/PayoutLineData")]
    public class PayoutLineDataAsset : ScriptableObject
    {
        [SerializeField] private PayoutLineData _data;
        public PayoutLineData data => _data;
    }
}