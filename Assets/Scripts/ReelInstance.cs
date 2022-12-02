using UnityEngine;
using Anino.Framework;
using Anino.Implementation;

public class ReelInstance : MonoBehaviour
{
    [SerializeField] private ReelDataAsset _reelData;
    [SerializeField] private SpriteRenderer symbolPrefab;
    private IReelController _controller;

    private void Awake() 
    {
        CreateReel();
        _controller = new ReelController(_reelData.data.symbolsCount, _reelData.data.GetVerticalSpacing(), _reelData.data.GetEndPosition(), OnSpin);
    }

    private void CreateReel()
    {
        float yPosition = -_reelData.data.GetVerticalSpacing();

        for(int i=0; i<_reelData.data.symbols.Length; i++)
        {
            SpriteRenderer symbol = Instantiate(symbolPrefab, transform);
            symbol.sprite = _reelData.data.symbols[i];

            symbol.transform.localPosition = Vector3.up * yPosition;
            yPosition += _reelData.data.GetVerticalSpacing();
        }
    }

    public void Spin()
    {
        _controller.Spin();
        StartCoroutine(_controller.Spinning());
    }

    public void Stop()
    {
        _controller.StopSpin();
    }

    private void OnSpin(float position)
    {
        transform.position = new Vector3(transform.position.x, position, transform.position.z);
    }
}
