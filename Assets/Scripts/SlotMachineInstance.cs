using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineInstance : MonoBehaviour
{
    [SerializeField] private ReelInstance[] reels;
    private WaitForSeconds _delay = new WaitForSeconds(0.1f);

    private bool _isSpinning = false;
    
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
        foreach(var reel in reels)
        {
            reel.Spin();
            yield return _delay;
        }
    }

    private IEnumerator StopSpin()
    {
        foreach(var reel in reels)
        {
            reel.Stop();
            yield return _delay;
        }
    }
}
