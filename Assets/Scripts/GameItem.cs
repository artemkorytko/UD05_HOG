using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace HOG
{
    public class GameItem : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private float _scaleDuration = 0.5f;
        [SerializeField] private float _scaleFactor = 1.5f;
        private SpriteRenderer _spriteRenderer;

        public event Action<string> OnFind; // event - вызов события может произойти только в этом же классе с наружи не может!! 
        
        public void Initialise()
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
                () => _spriteRenderer.DOFade(0,_scaleDuration).OnComplete(OffFind));
            
        }

        private void OffFind()
        {
            gameObject.SetActive(false);
            OnFind?.Invoke(_id);
        }
    }
}