using UnityEngine;
using Anino.Framework;
using Anino.Implementation;
using System;
using TMPro;

public class CombinationItemInstance : MonoBehaviour, ICombinationItemView
{
    [Serializable]
    public struct MainComponents
    {
        public Transform CellParent;
        public TextMeshProUGUI LineText;
        public GameObject BlankCellPrefab;
        public GameObject MarkedCellPrefab;
    }

    [SerializeField] private MainComponents _mainComponents;

    public ICombinationItemController controller => _controller;
    private ICombinationItemController _controller;

    public void Initialize()
    {
        _controller = new CombinationItemController();
        _controller.SetView(this);
    }

    public void UpdateLineText()
    {
        _mainComponents.LineText.text = $"Line {transform.GetSiblingIndex() + 1}";
    }

    public void AddBlankCell()
    {
        Instantiate(_mainComponents.BlankCellPrefab, _mainComponents.CellParent);
    }

    public void AddMarkedCell()
    {
        Instantiate(_mainComponents.MarkedCellPrefab, _mainComponents.CellParent);
    }
}
