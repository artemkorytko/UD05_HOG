using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GRADIENT : MonoBehaviour
{

    [SerializeField] private Gradient _gradient;
    [SerializeField] private float _duration;
    private SpriteRenderer _thisSprite;
    
    private void Awake()
    {
        
        _thisSprite = GetComponent<SpriteRenderer>(); //нашли спрайт в поле инспектора
    }

    
    void Start()
    {

        var gradient_1 = new Gradient();
        
        var duckStartX = transform.position.x;
        var duckStartY = transform.position.y;
            
        


        DOTween.Sequence()
            .Append(transform.DOMove(new Vector3(duckStartX, (duckStartY+5), 0), 1)).SetEase(Ease.InOutSine)
            .Join(_thisSprite.DOGradientColor(_gradient, _duration)) //градиент было дальше .SetEase(Ease.Linear)
            .AppendInterval(1)
            .Append(transform.DOMove(new Vector3(duckStartX, duckStartY, 0), 1)).SetEase(Ease.InBack)
            .SetLoops(-1); 
        
        /*
            
            
       // var gradient_2 = new Gradient();

       // Populate the color keys at the relative time 0 and 1 (0 and 100%)
       var colorKey_1 = new GradientColorKey[2];
       colorKey_1[0].color = Color.red;
       colorKey_1[0].time = 0.0f;
       colorKey_1[1].color = Color.blue;
       colorKey_1[1].time = 1.0f;

       var colorKey_2 = new GradientColorKey[2];
       colorKey_2[0].color = Color.green;
       colorKey_2[0].time = 0.0f;
       colorKey_2[1].color = Color.yellow;
       colorKey_2[1].time = 1.0f;
       
       // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
       var alphaKey = new GradientAlphaKey[2];
       alphaKey[0].alpha = 1.0f;
       alphaKey[0].time = 0.0f;
       alphaKey[1].alpha = 0.0f;
       alphaKey[1].time = 1.0f;

       gradient_1.SetKeys(colorKey_1, alphaKey);
       gradient_1.Evaluate(0.5f);
       gradient_2.SetKeys(colorKey_2, alphaKey);
       gradient_2.Evaluate(0.5f);
      
      
       DOTween.Sequence()
           .Append(_thisSprite.DOGradientColor(gradient_1, 1.3f) )
           .Append(_thisSprite.DOGradientColor(gradient_2, 1.3f) )
           .SetLoops(-1);
           */

       // _thisSprite.DOGradientColor(gradient_1, 1.3f);




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
