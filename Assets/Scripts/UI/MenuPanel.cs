using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HOG
{
    public class MenuPanel : MonoBehaviour
    {
       [SerializeField] private Button _playButton;
       
       [Header("Setting Animation")]
       [SerializeField] private Vector3 _maxScaleButton;
       [SerializeField] private float _durationAnimationButton;
       
       private CanvasGroup _canvasGroup;
       private Sequence _sequence;
       private Vector3 _firstScaleButton;

       public event Action Play;
       
       private void Awake()
       {
           _canvasGroup = GetComponent<CanvasGroup>();
           _sequence = DOTween.Sequence();
           _firstScaleButton = _playButton.transform.localScale;
       }

       private void OnEnable()
       {
           _playButton.onClick.AddListener(OnPlay); 
           StartAnimation();
       }

       private void OnDisable()
       {
           _playButton.onClick.RemoveListener(OnPlay);
           _sequence.Kill();
       }

       private void OnPlay()
       {
           _canvasGroup.DOFade(0, 2).SetEase(Ease.Linear);
           Play?.Invoke();
       }

       private void StartAnimation()
       {
           _sequence.Append(_playButton.transform.DOScale(_maxScaleButton, _durationAnimationButton));
           _sequence.Append(_playButton.transform.DOScale(_firstScaleButton, _durationAnimationButton));
           _sequence.SetLoops(-1);
       }

    }
}