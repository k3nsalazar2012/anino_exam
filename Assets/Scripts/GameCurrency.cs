using System;
using Anino.Framework;
using Anino.Implementation;
using UnityEngine;
using Zenject;
using TMPro;

public class GameCurrency : MonoBehaviour, ICurrencyView, ICurrencySubscriber
{
    [Serializable]
    public struct MainComponents
    {
        public TextMeshProUGUI CurrencyText;
    }

    [SerializeField] private MainComponents _mainComponents;

    private ICurrencyService _currencyService;
    public ICurrencyController controller => _controller;
    private ICurrencyController _controller;

    private void Awake() 
    {
        Debug.Log($"[controller] {_controller==null}");
    }

    [Inject]
    public void Construct(DiContainer container, ICurrencyService currencyService)
    {
        _controller = new CurrencyController();
        _controller.SetView(this);

        _currencyService = currencyService;
        ICurrency currency = container.Instantiate<Currency>();
        
        _currencyService.Subscribe(this);

        currency.SetAmount(1000000);
        _currencyService.SetCurrency(currency);
    }

    public void OnCurrencyUpdated(long amount)
    {
        Debug.Log($"[controller] {_controller==null}");
        _controller.SetCurrencyAmount(amount);
    }

    public void UpdateCurrencyText(long amount)
    {
        _mainComponents.CurrencyText.text = $"${amount.ToString("N0")}";  
    }
}
