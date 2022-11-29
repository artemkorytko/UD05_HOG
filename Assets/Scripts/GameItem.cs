using System;
using DG.Tweening;
using UnityEngine;

namespace HOG
{
    public class GameItem : MonoBehaviour
    {
        [SerializeField] private float scaleFactor = 1.5f;
        [SerializeField] private float scaleDuration = 0.5f;
        private SpriteRenderer _spriteRenderer;

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
            var startScale = transform.localScale;
            transform.DOScale(startScale * scaleFactor, scaleDuration).OnComplete(
                () => _spriteRenderer.DOFade(0, scaleDuration).OnComplete(
                    () =>  gameObject.SetActive(false)));
        }

        private void TurnOff()
        {
            gameObject.SetActive(false);
        }
    }
}