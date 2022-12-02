using System.Collections;
using Anino.Framework;
using UnityEngine;
using System;

namespace Anino.Implementation
{
    public class ReelController : IReelController, IReelViewObserver
    {
        public Action<float> onSpin {get; set;}
        public Action<int, int, int> onSpinEnded {get;set;}

        private bool _isSpinning;
        public bool isSpinning => _isSpinning;

        private WaitForSeconds _delay;
        private float _speed, _correctSpinValue, _currentPosition, _verticalSpacing, _endPosition;
        private int _symbolCount;
        private IReelView _view;
        private IReelData _data;
        
        public ReelController(int symbolCount, float verticalSpacing, float endPosition)
        {
            _symbolCount = symbolCount;
            _verticalSpacing = verticalSpacing;   
            _endPosition = endPosition;

            _isSpinning = false;  
            _currentPosition = 0;
            _delay = new WaitForSeconds(0.001f);
        }

        public void SetData(IReelData data)
        {
            _data = data;
        }

        public void SetView(IReelView view)
        {
            _view = view;
            _view.CreateReel();
            _view.SetObserver(this);
        }

        public void Spin()
        {
            _speed = UnityEngine.Random.Range(0.02f, 0.05f);
            _isSpinning = true;
        }

        public void StopSpin()
        {
            _isSpinning = false;
            _correctSpinValue = GetPositionToSymbolIndex() * _verticalSpacing;
            _currentPosition = _correctSpinValue;
            onSpin?.Invoke(_currentPosition);
            onSpinEnded?.Invoke
            (
                _data.symbols[GetTopRowResult()],
                _data.symbols[GetMiddleRowResult()],
                _data.symbols[GetBottomRowResult()]
            );
        }

        public IEnumerator Spinning()
        {
            while(_isSpinning)
            {
                _currentPosition -= _speed;
                onSpin?.Invoke(_currentPosition);

                if(_currentPosition <= _endPosition)
                {
                    _currentPosition = 0;
                    onSpin?.Invoke(_currentPosition);
                }

                yield return _delay;
            }
        }
        
        public int GetTopRowResult()
        {
            int topRowResult = GetMiddleRowResult() + 1;
            if(topRowResult >= _symbolCount)
                topRowResult = 0;

            return topRowResult;
        }

        public int GetMiddleRowResult()
        {
            int middleRowResult =  Mathf.Abs(GetPositionToSymbolIndex());
            if(middleRowResult == _symbolCount)
                middleRowResult = 0;

            return middleRowResult;
        }

        public int GetBottomRowResult()
        {
            int bottomRowResult = GetMiddleRowResult() - 1;
            if(bottomRowResult < 0)
                bottomRowResult = _symbolCount-1;

            return bottomRowResult;
        }

#if UNITY_EDITOR
        public virtual void SetPosition(float position)
        {
            _currentPosition = position;
            if(position > _endPosition)
                _currentPosition = 0;
        }
#endif
        private int GetPositionToSymbolIndex()
        {
            return Mathf.RoundToInt(_currentPosition / _verticalSpacing);
        }

        public void OnSpinInteract(MonoBehaviour mono)
        {
            Spin();
            mono.StartCoroutine(Spinning());
        }

        public void OnStopSpinInteract()
        {
            StopSpin();
        }
    }
}