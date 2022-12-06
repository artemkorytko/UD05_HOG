using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class COLORING : MonoBehaviour
{
    private SpriteRenderer _thisSprite;
    
    private void Awake()
    {
        _thisSprite = GetComponent<SpriteRenderer>(); //нашли спрайт в поле инспектора
    }

    
    void Start()
    {
        /* ---------- отлично работающее перекрашивание в зеленый --------
        var _thissprite = GetComponent<SpriteRenderer>();
        DOTween.Sequence()
           .Append(_thissprite.DOColor(Color.green, 1))
           .SetLoops(-1) ;
        */

        
        
        var thisspriteRED = _thisSprite.color.r; //красный
        var thisspriteBLUE = _thisSprite.color.b;
        var thisspriteGREEN = _thisSprite.color.g;
        var thisspriteGRAY = _thisSprite.color.grayscale;
       
        
        DOTween.Sequence()
            .Append(_thisSprite.DOColor(Color.green, 0.3f) )
            .Append(_thisSprite.DOColor(Color.blue, 0.3f) )
            .SetLoops(-1);
        
        
        
        
        //var snailStartX = transform.position.x;
        //var snailStartY = transform.position.y;
        
        // var snailScale = transform.localScale;
        /*
       DOTween.Sequence()
           .Append(_thisSprite.DOBlendableColor(Color.red, 0.3f) )
           .Append(_thisSprite.DOBlendableColor(Color.blue, 0.3f) )
           .SetLoops(-1);
 */
       
       
      // LoopType.Incremental
      //transform.localScale = kozel;

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
