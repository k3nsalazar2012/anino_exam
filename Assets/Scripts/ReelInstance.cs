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
        var data = _reelData.data;

        float yPosition = -data.GetVerticalSpacing();

        SpriteRenderer symbol = Instantiate(_symbolPrefab, transform);
        symbol.sprite = data.symbolSprites[data.symbols[_reelData.data.symbolsCount-1]-1];
        symbol.transform.localPosition = Vector3.up * yPosition;

        yPosition += data.GetVerticalSpacing();

        for(int i=0; i<data.symbols.Length; i++)
        {
            symbol = Instantiate(_symbolPrefab, transform);
            symbol.sprite = data.symbolSprites[data.symbols[i]-1];

            symbol.transform.localPosition = Vector3.up * yPosition;
            yPosition += data.GetVerticalSpacing();
        }

        for(int i=0; i<2; i++)
        {
            symbol = Instantiate(_symbolPrefab, transform);
            symbol.sprite = data.symbolSprites[data.symbols[i]-1];

            symbol.transform.localPosition = Vector3.up * yPosition;
            yPosition += data.GetVerticalSpacing();
        }
    }

    public void Spin() => _observer.OnSpinInteract(this);
    public void Stop() => _observer.OnStopSpinInteract();
    public void OnSpin(float position) => transform.position = new Vector3(transform.position.x, position, transform.position.z);
}
