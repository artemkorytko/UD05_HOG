using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HOG
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private Button _nextLevelButton;
        
        [Header("Setting Animation")]
        [SerializeField] private Vector3 _maxScaleButton;
        [SerializeField] private float _durationAnimationButton;
        
        private CanvasGroup _canvasGroup;
        private Sequence _sequence;
        private Vector3 _firstScaleButton;
        
        public event Action NextLevl;
       
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _sequence = DOTween.Sequence();
            _firstScaleButton = _nextLevelButton.transform.localScale;
        }

        private void OnEnable()
        {
            _nextLevelButton.onClick.AddListener(OnNextLevel);
            StartAnimation();
        }

        private void OnDisable()
        {
            _nextLevelButton.onClick.RemoveListener(OnNextLevel);
            _sequence.Kill();
        }

        private void OnNextLevel()
        {
            _canvasGroup.DOFade(0, 2).SetEase(Ease.Linear);
            NextLevl?.Invoke();
        }

        private void StartAnimation()
        {
            _sequence.Append(_nextLevelButton.transform.DOScale(_maxScaleButton, _durationAnimationButton));
            _sequence.Append(_nextLevelButton.transform.DOScale(_firstScaleButton, _durationAnimationButton));
            _sequence.SetLoops(-1);
        }
    }
}