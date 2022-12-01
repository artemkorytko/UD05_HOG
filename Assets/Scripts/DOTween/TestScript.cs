using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
  [SerializeField] private Color _color;
  [SerializeField] private Vector3 _target;
  [SerializeField] private Vector3 _strength;

  [SerializeField] private float _duration;
  [SerializeField] private Gradient _gradient;

  private Sequence _sequence;
  private SpriteRenderer _sprite;

  private void Awake()
  {
    _sequence = DOTween.Sequence();
    _sprite = GetComponent<SpriteRenderer>();
  }

  private void Start()
  {
    Vector3 firstPoint = transform.position;
    Color firstColor = _sprite.color;
    
    
    _sequence.Append(transform.DOMove(_target, _duration).SetEase(Ease.Linear));
    //_sequence.Join(GetComponentInChildren<Transform>().DOMove(new Vector3(0,1,0), 0.5f).SetDelay(_duration));
    _sequence.Append(transform.DOMove(firstPoint, _duration).SetEase(Ease.Linear));
    
    _sequence.Join(transform.DOShakeScale(0.5f, _strength));
  
    _sequence.SetLoops(-1).SetDelay(0.5f);
  }
}
