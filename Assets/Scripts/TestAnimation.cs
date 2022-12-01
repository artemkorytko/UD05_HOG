using System;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

namespace HOG
{
    public enum AnimationType
    {
        None,
        Move,
        Rotate,
        Jump,
        Scale,
        Seq
    }

    public class TestAnimation : MonoBehaviour
    {
        [SerializeField] private AnimationType animationType;
        private Transform _childTransform;

        private Tween _moveTween;
        private Tween _rotateTween;

        private void Awake()
        {
            _childTransform = transform.GetChild(0);
        }

        private void Start()
        {
            switch (animationType)
            {
                case AnimationType.None:
                    Debug.Log("No animation");
                    break;
                case AnimationType.Move:
                    MoveAnimation();
                    break;
                case AnimationType.Rotate:
                    RotateAnimation();
                    break;
                case AnimationType.Jump:
                    JumpAnimation();
                    break;
                case AnimationType.Scale:
                    ScaleAnimation();
                    break;
                case AnimationType.Seq:
                    SeqAnimation();
                    break;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _moveTween?.Kill();
            }
        }

        private void SeqAnimation()
        {
            Sequence sequence = DOTween.Sequence();
            
            sequence.Append(transform.DOMove(transform.position + Vector3.left * 2, 1));
            sequence.AppendInterval(1);
            sequence.Append(transform.DOScale(transform.localScale * 2, 1));
            sequence.AppendCallback(() => Debug.Log("Will be jump"));
            sequence.Append(transform.DOJump(transform.position + Vector3.right * 2, 2, 1, 1)).Join(transform.DOScale(Vector3.one, 1));
            sequence.OnComplete(SeqAnimation);//рекурсия
        }

        private void ScaleAnimation()
        {
            transform.DOScale(transform.localScale * 2, 1).SetLoops(-1, LoopType.Yoyo);
        }

        private void JumpAnimation()
        {
            transform.DOJump(transform.position + Vector3.right * 2, 2, 1, 1).SetLoops(-1, LoopType.Yoyo);
        }

        private void RotateAnimation()
        {
            transform.DORotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
        }

        private void MoveAnimation()
        {
            _moveTween = transform.DOMove(transform.position + Vector3.left * 2, 1).SetLoops(-1, LoopType.Yoyo);
            transform.DOScale(transform.localScale * 2, 1).SetLoops(-1, LoopType.Yoyo);
            _rotateTween = _childTransform.DOLocalRotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
        }
    }
}