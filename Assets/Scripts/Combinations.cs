using Anino.Framework;
using Anino.Implementation;
using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;

public class Combinations : MonoBehaviour, ICombinationsView
{
    [Serializable]
    public struct MainComponents
    {
        public Transform CombinationsParent;
        public CombinationItemInstance CombinationItem;
    }

    [SerializeField] private PayoutLineDataAsset[] _payoutLines;
    [SerializeField] private MainComponents _mainComponents;

    public ICombinationsController controller => _controller;
    private ICombinationsController _controller;

    private void Awake()
    {
        _controller = new CombinationsController();
        _controller.SetView(this);
        _controller.SetData(_payoutLines.Select(l => l.data).ToArray());
    }

    public void ShowCombinations(List<List<int>> combinations)
    {
        for(int i=0; i<combinations.Count; i++)
        {
            var combinationItem = Instantiate(_mainComponents.CombinationItem, _mainComponents.CombinationsParent);
            combinationItem.Initialize();
            combinationItem.GetComponent<ICombinationItemView>().controller.SetData(combinations[i]);
        }
        Debug.Log($"[show combinations]");
    }
}
