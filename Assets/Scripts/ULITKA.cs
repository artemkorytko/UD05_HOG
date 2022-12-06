using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ULITKA : MonoBehaviour
{
    private SpriteRenderer _ulitkaSprite; //переменная для поиска спрайта улитки
    // Start is called before the first frame update
    private void Awake()
    {
        _ulitkaSprite = GetComponent<SpriteRenderer>(); //нашли спрайт в поле инспектора
    }

    
    void Start()
    {
        //var snailfadePRM = _ulitkaSprite.color.a; //alfa !!!!!!
        //var snailStartX = transform.position.x;
        //var snailStartY = transform.position.y;
        
       // var snailScale = transform.localScale;
       DOTween.Sequence()
           .Append(_ulitkaSprite.DOFade(0.5f, 2) )
           .Append(_ulitkaSprite.DOFade(1, 2) )
           .SetLoops(-1);

       //transform.DOScale(10, 1).OnComplete(
       //() => _ulitkaSprite.DOFade(0, 4) );

    }
    

    // Update is called once per frame
    void Update()
    {
        //ransform.DOMove(new Vector3(2,3,0), 3).SetLoops(-1);
        /*
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, 5 * Time.deltaTime);
        */
       // Debug.Log("X:" + transform.position.x + ", Y:" + transform.position.y) ;
        
    }
}
