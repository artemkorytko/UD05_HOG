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
       private CanvasGroup _canvasGroup;

       public event Action Play;
       
       private void Awake()
       {
           _canvasGroup = GetComponent<CanvasGroup>();
       }
       
       private void Start()
       {
           _playButton.onClick.AddListener(OnPlay);
       }

       private void OnDestroy()
       {
           _playButton.onClick.RemoveListener(OnPlay);
       }

       private void OnPlay()
       {
           _canvasGroup.DOFade(0, 2).SetEase(Ease.Linear);
           Play?.Invoke();
       }
       
    }
}