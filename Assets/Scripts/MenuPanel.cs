using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private CanvasGroup _Canvas;

    private Sequence _sequence; // секвенция будет отвечать за последователньность работы анимации
    //public void StartGame() //StartGame будет висеть на конпке начала игры, то есть тут надо прописать логику кликанья на кнопку и перемещения на Левел

    private void Awake()
    {
        _sequence = DOTween.Sequence(); // присваиваю секвенции функции секвенции от (класс дутвин содержит функцию секвенции)
        Animation(); // вызываем в Awake метод Animation, чтобы Animation вообще вызвался и отработал
    }

    private void Animation() //в анимации будет запускаться анимация
    {
        
        _sequence.Append(_playButton.transform.DOScale(new Vector3(1.1f, 1.1f, 1), 1));
    /*Append - добавляет то, что мы ей передаем(анимацию кнопки, т е того что прописано в скобках). 
            передаем мы ей playButton, чтобы анимировать кнопку, передаем transform; DoScale- и есть та трансформация, 
            DoScale-трансформация размера. new Vector 3 - в него передаем конечные размеры до которых увеличиваем
            Анимация (т е увеличение до размеров (1.1; 1.1; 1) будет происходить всего один раз!
         */

    _sequence.Append(_playButton.transform.DOScale(new Vector3(1, 1, 1), 1));
    /*здесь анимация уменьшения, тоже происходит всего один раз */

    _sequence.SetLoops(-1); //_sequence (увеличение и уменьшение будет бесконечно повторяться), -1 - значит повторяться будет бесконечно

    }

    public void Play() //повесим эту функцию на кнопку, и при клике на кнопку отрботает этот метод
    {
        _Canvas.DOFade(0, 1); /*на канвасе висит метод doFade(doFade - метод класса doTween), 
        Fade - скрывает объект КанвасГруп(к которому мы обратились через _Канвас) до конечного значения 0(т е исчезнет) за 1 секунду
        */
        
        _sequence.Kill();//то есть при запуске метода play, _sequence перестанет работат(=> перестает работать анимации кнопки, при начале работы уровня), то есть убиваем все что связанол с секвенцией

    }
    
    
}
