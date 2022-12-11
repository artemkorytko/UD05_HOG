using System;
using UnityEngine;


public class WinPanel : MonoBehaviour
{ 
    // [SerializeField] private Button _newButton;
    [SerializeField] private CanvasGroup _Canvas;

    public event Action _win; //Action - как рация, подписываемся на обновления какого-либо события 
    
    //private Sequence _sequence; // секвенция будет отвечать за последователньность работы анимации
    //public void StartGame() //StartGame будет висеть на конпке начала игры, то есть тут надо прописать логику кликанья на кнопку и перемещения на Левел

    private void Awake()
    {
       // _sequence = DOTween.Sequence(); // присваиваю секвенции функции секвенции от (класс дутвин содержит функцию секвенции)
       // Animation(); // вызываем в Awake метод Animation, чтобы Animation вообще вызвался и отработал
    }

    
    public void Play() //повесим эту функцию на кнопку, и при клике на кнопку отрботает этот метод
    {
       // _Canvas.DOFade(0, 1); /*на канвасе висит метод doFade(doFade - метод класса doTween), 
       // Fade - скрывает объект КанвасГруп(к которому мы обратились через _Канвас) до конечного значения 0(т е исчезнет) за 1 секунду
        //*/
        
       // _sequence.Kill();//то есть при запуске метода play, _sequence перестанет работат(=> перестает работать анимации кнопки, при начале работы уровня), то есть убиваем все что связанол с секвенцией
        _win?.Invoke();//оповещение о действии (нажатии кнопки (NextLevel после окончания игры)_win - переменная метода Action)((т к весь метод Play(прописываемый здесь) отработает при нажатии на кнопку =>_play?.Invoke() - оповещение о нажатии на кнопку)
        
    }

   

}
