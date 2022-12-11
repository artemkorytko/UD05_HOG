using System;
using DG.Tweening;
using UnityEngine;

namespace HOG
{
    public class GameItem : MonoBehaviour
    {
        
        [SerializeField] private string id;
        [SerializeField] private float scaleFactor = 1.5f;
        [SerializeField] private float scaleDuration = 0.5f;
        
        private SpriteRenderer _spriteRenderer;//SpriteRenderer - компонент(т е тип переменной), sprite renderer в юнити позволяет отображать изображения в виде спрайтов(спрайт - геометрическая фигура на которую нанесена картинка(т е текстура), т е спрайт - объект в игре)
        

        public event Action<string> OnFind;
        public Sprite Sprite => _spriteRenderer.sprite;

        public string ID => id;

        public void Initialize() 
        {
            _spriteRenderer = GetComponent<SpriteRenderer>(); //GetComponent - функция для обращения к компоненту, SpriteRenderer - компонент, к которому обращаемся
        }

        private void OnMouseUpAsButton() //ф-ция OnMouseUpAsButton - вызывается только тогда, когда мышь отпустили над тем же коллайдером над которым зажали
        {
            Find();
        }

        
        private void Find() 
        {
            var startScale = transform.localScale; //ввели переменную startScale; transform, localScale - функции из unity => startScale отвечает за преобразование масштаба относительно родидетя GameObject
            transform.DOScale(startScale * scaleFactor, scaleDuration).OnComplete(()=>_spriteRenderer.DOFade(0, scaleDuration).OnComplete(TurnOff));
            
        }

        private void TurnOff()
        {
            gameObject.SetActive(false);
            OnFind?.Invoke(ID);

            
        }

       

        
    }
}