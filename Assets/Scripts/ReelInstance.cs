using UnityEngine;
using Anino.Framework;
using Anino.Implementation;

public class ReelInstance : MonoBehaviour, IReelView
{
    [SerializeField] private ReelDataAsset _reelData;
    [SerializeField] private SpriteRenderer _symbolPrefab;
    public IReelController controller => _controller;
    private IReelController _controller;
    private IReelViewObserver _observer;

    public void Initialize() 
    {
        _controller = new ReelController(_reelData.data.symbolsCount, _reelData.data.GetVerticalSpacing(), _reelData.data.GetEndPosition()); 
        _controller.SetData(_reelData.data);
        _controller.SetView(this);
        _controller.onSpin += OnSpin;
    }

    public void SetObserver(IReelViewObserver observer) => _observer = observer;

    public void CreateReel()
    {
        float yPosition = -_reelData.data.GetVerticalSpacing();

        for(int i=0; i<_reelData.data.symbolSprites.Length; i++)
        {
            SpriteRenderer symbol = Instantiate(_symbolPrefab, transform);
            symbol.sprite = _reelData.data.symbolSprites[i];

            symbol.transform.localPosition = Vector3.up * yPosition;
            yPosition += _reelData.data.GetVerticalSpacing();
        }
    }

    public void Spin() => _observer.OnSpinInteract(this);
    public void Stop() => _observer.OnStopSpinInteract();
    public void OnSpin(float position) => transform.position = new Vector3(transform.position.x, position, transform.position.z);
}
