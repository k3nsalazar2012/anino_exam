using System;
using Anino.Framework;
using Anino.Implementation;
using UnityEngine;
using Zenject;
using TMPro;

public class GameCurrency : MonoBehaviour, ICurrencyView, ICurrencySubscriber, IPayoutSubscriber
{
    [Serializable]
    public struct MainComponents
    {
        public TextMeshProUGUI CurrencyText;
        public TextMeshProUGUI WinText;
    }

    [SerializeField] private MainComponents _mainComponents;

    private ICurrencyService _currencyService;
    private IPayoutService _payoutService;
    public ICurrencyController controller => _controller;
    private ICurrencyController _controller;

    private void Awake() 
    {
        Debug.Log($"[controller] {_controller==null}");
    }

    [Inject]
    public void Construct(DiContainer container, ICurrencyService currencyService, PayoutService payoutService)
    {
        _controller = new CurrencyController();
        _controller.SetView(this);

        _currencyService = currencyService;
        _payoutService = payoutService;
        
        _payoutService.Subscribe(this);

        ICurrency currency = container.Instantiate<Currency>();
        
        _currencyService.Subscribe(this);

        currency.SetAmount(1000000);
        _currencyService.SetCurrency(currency);
    }

    public void OnCurrencyUpdated(long amount)
    {
        _controller.SetCurrencyAmount(amount);
    }

    public void UpdateCurrencyText(long amount)
    {
        _mainComponents.CurrencyText.text = $"${amount.ToString("N0")}";  
    }

    public void OnWin(int payoutLinesCount)
    {
        _mainComponents.WinText.text = $"Win: ${(_currencyService.betAmount * payoutLinesCount).ToString("N0")}";
    }
}
