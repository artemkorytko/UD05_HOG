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
        private CanvasGroup _canvasGroup;

        public event Action NextLevl;
       
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            _nextLevelButton.onClick.AddListener(OnNextLevel);
            _canvasGroup.DOFade(1, 2).SetEase(Ease.Linear);
        }
        
        private void OnDisable()
        {
            _nextLevelButton.onClick.RemoveListener(OnNextLevel);
        }

        private void OnNextLevel()
        {
            _canvasGroup.DOFade(0, 2).SetEase(Ease.Linear);
            NextLevl?.Invoke();
        }
        
    }
}