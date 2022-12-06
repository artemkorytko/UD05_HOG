using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

// ---------------------- тестовая анимация двигающейся утки с Kill анимации в конце --------------------------------
public class DOTweenTEST : MonoBehaviour
{
    private Sequence _duckanimation; //тут объявляем название анимации
    int duckMoves = 1;

    private void Awake()
    {
        _duckanimation = DOTween.Sequence(); //в авейке заявляем что ща буду её анимировать дотвином
    }


    void Start()
    {
        var duckStartX = transform.position.x;
        var duckStartY = transform.position.y;

        //тут просто к ней обращаемся и анимируем
        _duckanimation.Append(transform.DOMove(new Vector3((duckStartX + 3), duckStartY, 0), 1))
            .SetEase(Ease.InOutSine);
        
        _duckanimation.AppendInterval(1);
        _duckanimation.Append(transform.DOMove(new Vector3(duckStartX, duckStartY, 0), 1)).SetEase(Ease.InBack);
        _duckanimation.AppendCallback(CountDuckMoves);
        _duckanimation.SetLoops(-1);
    }


    private void CountDuckMoves()
    {
        Debug.Log($"Duck moved #{duckMoves}");
        duckMoves++;
    }

    // ------------ на дистрой - принудительно киляет именованную выше анимацию -----------------------------
    private void OnDestroy()
    {
        _duckanimation?.Kill(true);
    }
}