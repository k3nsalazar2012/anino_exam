using UnityEngine;
using Anino.Framework;

namespace Anino.Implementation
{
    [CreateAssetMenu(menuName = "Anino/Data/ReelData")]
    public class ReelDataAsset : ScriptableObject
    {
        [SerializeField] private ReelData _data;
        public IReelData data => _data;
    }
}