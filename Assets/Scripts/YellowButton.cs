using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

//----------------------- анимация отдельного тестового батона --------------------------
public class YellowButton : MonoBehaviour
{
    private Sequence _batonanimation;
    //private SpriteRenderer _ulitkaSprite; //переменная для поиска спрайта улитки
    // Start is called before the first frame update
    private void Awake()
    {
        _batonanimation = DOTween.Sequence();
    }

    
    void Start()
    { 
        var kozel = transform.localScale.x;
        var scaleparam = 1.2f;

        if (_batonanimation != null)
        {
            _batonanimation.Append(transform.DOScaleX((kozel * scaleparam), 0.2f));
            _batonanimation.Append(transform.DOScaleX(kozel, 1).SetEase(Ease.InOutElastic));
            _batonanimation.SetLoops(-1);
        }

    }
    

    private void OnDestroy()
    {
        _batonanimation?.Kill(true);
    }
}
