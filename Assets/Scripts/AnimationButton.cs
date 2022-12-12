using DG.Tweening;
using UnityEngine;

namespace HOG
{
    //висит на каждой кнопке в UI
    public class AnimationButton : MonoBehaviour
    {
        private Sequence _sequence;

        private void OnEnable()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(Vector3.one * 1.5f, 1));
            _sequence.Append(transform.DOScale(Vector3.one, 1));
            _sequence.SetLoops(-1);
        }

        private void OnDisable()
        {
            _sequence?.Kill(true);
        }
    }
}