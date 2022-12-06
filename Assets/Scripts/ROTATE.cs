using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ROTATE : MonoBehaviour
{
    private Vector3 rot;
    // Start is called before the first frame update
    private void Awake()
    {
        rot = new Vector3(0, 0, 360);
    }

    
    void Start()
    {
        //var snailStartX = transform.position.x;
        //var snailStartY = transform.position.y;
        
       //var kozel = transform;

       //var scaleparam = 1.2f;
        
       // scale.x = 3f;
        //recTransform.sizeDelta = scale;
       // var snailScale = transform.localScale;
       //var rot = transform.Rotate(0, 360, 0);
       
       
       DOTween.Sequence()
           .Append(transform.DORotate(rot,2, RotateMode.FastBeyond360))
           .SetLoops(-1) ;

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
