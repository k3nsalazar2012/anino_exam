using UnityEngine;
using Anino.Framework;
using TMPro;
using Zenject;
using Anino.Implementation;
using System;
using UnityEngine.UI;

public class Bet : MonoBehaviour, IBetView
{
    [Serializable]
    public struct MainComponents
    {
        public TextMeshProUGUI BetText;
        public Button IncreaseBetButton;
        public Button DecreaseBetButton;
    }

    [SerializeField] private MainComponents _mainComponents;
    public IBetController controller => _controller;
    private IBetController _controller;
    private ICurrencyService _currencyService;

    [Inject]
    public void Construct(DiContainer container, CurrencyService currencyService)
    {
        _currencyService = currencyService;
        _controller = container.Instantiate<BetController>();
        _controller.SetView(this);
        AddListeners();
    }

    public void UpdateBet(long amount)
    {
        _mainComponents.BetText.text = $"${amount.ToString("N0")}";
    }

    private void AddListeners()
    {
        _mainComponents.IncreaseBetButton.onClick.RemoveAllListeners();
        _mainComponents.IncreaseBetButton.onClick.AddListener(_controller.IncreaseBet);

        _mainComponents.DecreaseBetButton.onClick.RemoveAllListeners();
        _mainComponents.DecreaseBetButton.onClick.AddListener(_controller.DecreaseBet);
    }
}
