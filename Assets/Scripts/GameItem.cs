using System;
using DG.Tweening;
using UnityEngine;

namespace HOG
{
    public class GameItem : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private float _scaleDuration = 0.5f;
        [SerializeField] private float _scaleFactor = 1.5f;
        
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _collider;
        
        public string ID => _id;
        public Sprite Sprite => _spriteRenderer.sprite;
        public event Action<string> OnFind; 
        
        
        public void Initialise()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<BoxCollider2D>();
        }
        
        
        private void OnMouseUpAsButton()
        {
            _collider.enabled = false;
            Find();
        }

        
        private void Find()
        {
            transform.DOScale(transform.localScale * _scaleFactor, _scaleDuration).OnComplete(
                () => _spriteRenderer.DOFade(0,_scaleDuration).OnComplete(OffFind));
            
        }

        
        private void OffFind()
        {
            gameObject.SetActive(false);
            OnFind?.Invoke(_id);
        }
    }
}