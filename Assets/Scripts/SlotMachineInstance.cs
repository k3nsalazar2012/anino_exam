using System;
using System.Collections;
using System.Collections.Generic;
using Anino.Framework;
using UnityEngine;

public class SlotMachineInstance : MonoBehaviour
{
    [SerializeField] private ReelInstance[] _reels;
    private WaitForSeconds _delay = new WaitForSeconds(0.1f);

    private bool _isSpinning = false;
    
    private void Awake()
    {
        foreach(var reel in _reels)
        {
            var reelView = reel.GetComponent<IReelView>();
            reelView.Initialize();
            reelView.controller.onSpinEnded += SpinEnded;
        }
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
    }

    private void SpinEnded(int topRowResult, int middleRowResult, int bottomRowResult)
    {
         Debug.Log($"[results] {topRowResult},{middleRowResult},{bottomRowResult}");
    }
}
