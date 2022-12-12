using DG.Tweening;
using UnityEngine;

namespace HOG
{
    public class AnimationButton : MonoBehaviour
    {
        [Header("Setting Animation")]
        [SerializeField] private Vector3 _maxScaleButton;
        [SerializeField] private float _durationAnimationButton;
        
        private Sequence _sequence;
        
        private void OnEnable()
        {
            _sequence = DOTween.Sequence();
            StartAnimation();
        }
        
        private void OnDisable()
        {
            _sequence?.Kill(true);
        }
        
        private void StartAnimation()
        {
            _sequence.Append(transform.DOScale(_maxScaleButton, _durationAnimationButton)).SetEase(Ease.Linear);
            _sequence.Append(transform.DOScale(Vector3.one, _durationAnimationButton)).SetEase(Ease.Linear);
            _sequence.SetLoops(-1);
        }
        
    }
}