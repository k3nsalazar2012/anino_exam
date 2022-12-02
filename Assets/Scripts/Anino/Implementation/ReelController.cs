using System.Collections;
using Anino.Framework;
using UnityEngine;
using System;

namespace Anino.Implementation
{
    public class ReelController : IReelController
    {
        public Action<float> onSpin {get;}
        
        private bool _isSpinning;
        public bool isSpinning => _isSpinning;

        private WaitForSeconds _delay;
        private float _speed;
        private float _correctSpinValue;

        private float _verticalSpacing;
        private float _endPosition;
        private float _currentPosition;

        public ReelController(float verticalSpacing, float endPosition, Action<float> onSpinCallback)
        {
            _delay = new WaitForSeconds(0.001f);
            _isSpinning = false;   
            _verticalSpacing = verticalSpacing;   
            _endPosition = endPosition;
            _currentPosition = 0;
            onSpin = onSpinCallback;
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

            Debug.Log($"[index] {GetMiddleRowResult()}");
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

        public int GetMiddleRowResult()
        {
            return Mathf.Abs(GetPositionToSymbolIndex());
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
    }
}