using System.Collections;
using System.Collections.Generic;
using Anino.Framework;
using Anino.Implementation;
using UnityEngine;
using Zenject;
using TMPro;

public class SlotMachineInstance : MonoBehaviour, IPayoutSubscriber
{
    [SerializeField] private ReelInstance[] _reels;
    [SerializeField] private PayoutLineDataAsset[] _payoutLines;
    [SerializeField] private TextMeshProUGUI _winText;

    private WaitForSeconds _delay = new WaitForSeconds(0.1f);

    private bool _isSpinning = false;
    private List<List<int>> _results;
    private List<int> _singleArrayResults;
    private IPayoutService _payoutService;
    private ICurrencyService _currencyService;

    private void Awake()
    {
        foreach(var reel in _reels)
        {
            var reelView = reel.GetComponent<IReelView>();
            reelView.Initialize();
            reelView.controller.onSpinEnded += SpinEnded;
        }
    }

    [Inject]
    public void Construct(PayoutService payoutService, CurrencyService currencyService)
    {
        _payoutService = payoutService;
        _currencyService = currencyService;

        _payoutService.Subscribe(this);
        
        List<List<int>> lines = new List<List<int>>();
        foreach(var payoutLine in _payoutLines)
        {
             var line = payoutLine.data.GetDataAsSingleArray();
             lines.Add(line);
        }
        _payoutService.SetPayoutLines(lines);
    }

    public void OnSpinButton() 
    {
        _isSpinning = !_isSpinning;
        if(_isSpinning)
        {
            if(_currencyService.betAmount > _currencyService.currency.amount)
            {
                _isSpinning = false;
                return;
            }

            StartCoroutine(StartSpin());
        }
        else
            StartCoroutine(StopSpin());
    }

    private IEnumerator StartSpin()
    {
        _winText.text = "";
        _currencyService.RemoveCurrency(_currencyService.betAmount);
        _results = new List<List<int>>();

        foreach(var reel in _reels)
        {
            reel.Spin();
            yield return _delay;
        }
    }

    private IEnumerator StopSpin()
    {
        foreach(var reel in _reels)
        {
            reel.Stop();
            yield return _delay;
        }
        _payoutService.SetResults(_results);
    }

    private void SpinEnded(int topRowResult, int middleRowResult, int bottomRowResult)
    {
        List<int> reelResult = new List<int>{topRowResult, middleRowResult, bottomRowResult};
        _results.Add(reelResult);
    }

    public void OnWin(int payoutLinesCount)
    {
        _currencyService.AddCurrency(_currencyService.betAmount * payoutLinesCount);
        Debug.Log($"[payout] win: {payoutLinesCount}");
    }
}
