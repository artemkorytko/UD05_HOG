using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;



namespace HOG
{
    public class AnimatedButtonComponent : MonoBehaviour //AnimatedButtonComponent - будем вешать на саму кнопку
    {
       // private Button _button;//ссылка на компонент ( т е на кнопку)((на которую будем вешать анимацию))
        private Sequence _sequence; // ссылка на секвкнцию //Sequence - класс в Tweening
     
        
        private void Awake()
        {
            _sequence = DOTween.Sequence(); //присвоили секенции значение чтобы был не 0
            //_button = GetComponent<Button>();//переменной баттон присвоили компонент Button
            

        }

        private void OnEnable() //т е при тыке на кнопку в игре, она становится активна => вызывается OnEnable() каждыц раз при клике на кнопку
        {
            Animation();//вызываем метод Animation в OnEnable, чтобы во-первых он вызвался, во-вторых чтобы мог вызываться несколько раз (тк onEnable вызывается каждый раз при включении объекта, а включается в UiController'e при SetActive)
        }

        private void OnDisable()
        {
            _sequence.Kill();//то есть при запуске новой игры(что передается через event, set activе'ом меняется панель с win panel на game panel, о чем передаст invoke  => _sequence перестанет работат(=> перестает работать анимации кнопки, при начале работы уровня), то есть убиваем все что связанол с секвенцией
        }

        private void Animation() //в анимации будет запускаться анимация
        {
        
            _sequence.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1), 1));
            /*Append - добавляет то, что мы ей передаем(анимацию кнопки, т е того что прописано в скобках). 
                    передаем мы ей _button, чтобы анимировать кнопку, передаем transform; DoScale- и есть та трансформация, 
                    DoScale-трансформация размера. new Vector 3 - в него передаем конечные размеры до которых увеличиваем
                    Анимация (т е увеличение до размеров (1.1; 1.1; 1) будет происходить всего один раз!
                 */

            _sequence.Append(transform.DOScale(new Vector3(1, 1, 1), 1));
            /*здесь анимация уменьшения, тоже происходит всего один раз */

            _sequence.SetLoops(-1); //_sequence (увеличение и уменьшение будет бесконечно повторяться), -1 - значит повторяться будет бесконечно

        }
    }
}