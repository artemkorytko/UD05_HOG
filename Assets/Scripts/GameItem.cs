using System;
using DG.Tweening;
using UnityEngine;

namespace HOG
{
    public class GameItem : MonoBehaviour
    {
        [SerializeField] private string id;
        [SerializeField] private float scaleFactor = 1.5f;
        [SerializeField] private float scaleDuration = 1f;
        private SpriteRenderer _spriteRenderer;

        public event Action<string> OnFind;

        public string ID => id;
        public Sprite Sprite => _spriteRenderer.sprite;

        public void Initialize()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void OnMouseUpAsButton()
        {
            Find();
        }

        private void Find()
        {
            transform.DOScale(transform.localScale * scaleFactor, scaleDuration).OnComplete(
                () => _spriteRenderer.DOFade(0, scaleDuration).OnComplete(
                    TurnOff));
        }

        private void TurnOff()
        {
            gameObject.SetActive(false);
            OnFind?.Invoke(id);
        }
        
    }
}