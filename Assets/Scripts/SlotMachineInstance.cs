using System;
using System.Collections;
using System.Collections.Generic;
using Anino.Framework;
using Anino.Implementation;
using UnityEngine;
using Zenject;

public class SlotMachineInstance : MonoBehaviour
{
    [SerializeField] private ReelInstance[] _reels;
    [SerializeField] private PayoutLineDataAsset[] _payoutLines;
    
    private WaitForSeconds _delay = new WaitForSeconds(0.1f);

    private bool _isSpinning = false;
    private List<List<int>> _results;
    private List<int> _singleArrayResults;
    private PayoutService _payoutService;

    private void Awake()
    {
        foreach(var reel in _reels)
        {
            var reelView = reel.GetComponent<IReelView>();
            reelView.Initialize();
            reelView.controller.onSpinEnded += SpinEnded;
        }

        /*_payoutService = new PayoutService();
        List<List<int>> lines = new List<List<int>>();
        foreach(var payoutLine in _payoutLines)
        {
             var line = payoutLine.data.GetDataAsSingleArray();
             lines.Add(line);
        }
        _payoutService.SetPayoutLines(lines);*/
    }

    [Inject]
    public void Construct(PayoutService payoutService)
    {
        _payoutService = payoutService;
        Debug.Log($"[slot machine] {_payoutService == null}");
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
            StartCoroutine(StartSpin());
        else
            StartCoroutine(StopSpin());
    }

    private IEnumerator StartSpin()
    {
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
}
