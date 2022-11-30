using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace HOG
{
    public class GameItem : MonoBehaviour
    { 
        [SerializeField] private float _scaleDuration = 0.5f;
        [SerializeField] private float _scaleFactor = 1.5f;
        private SpriteRenderer _spriteRenderer;
        private Sequence mySequence = DOTween.Sequence();//????
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnMouseUpAsButton()
        {
            Find();
        }

        private void Find()
        {
            transform.DOScale(transform.localScale * _scaleFactor, _scaleDuration).OnComplete(
                () => _spriteRenderer.DOFade(0,_scaleDuration).OnComplete(
                    ()=> gameObject.SetActive(false)));
        }
    }
}