using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HOG
{
// отвечает за работук всех объектов на сцене и реагировать на нахождение
    public class Level : MonoBehaviour
    {
        private GameItem[] _gameItems; // массив для обектов - ежей и батонов
        private int _itemsCount; // переменная считать объекты - ежей и батоны 

        public event Action OnCompleted; //?? 
        public event Action<string> OnItemFind; //??

        public void Initialize()
        {
            //найти все объекты у кого есть компонент GameItem !!!!
            _gameItems = GetComponentsInChildren<GameItem>();
            
            //переменная которая считает сколько этих объектов в массиве
            _itemsCount = _gameItems.Length;


            for (int i = 0; i < _gameItems.Length; i++)
            {
                _gameItems[i].Initialize(); // создает в виртуальном массиве объект - батон
                _gameItems[i].OnFind += OnFindItem; // подписались на метод что батон будет найден / событие!!!! ждем команду на частоте
            }
        }

        //------------------------- когда нашли батон -------------------------------------
        private void OnFindItem(string id)
        {
            Debug.Log("Object find  " + id);
            
            // _itemsCount--;
            // минусование количества найденных объектов убрали в условие ! перед переменной
            if (--_itemsCount > 0) //уменьшить переменную кол-ва батонов, если остались еще объекты > 0
            {
                OnItemFind?.Invoke(id); //ждет 
            }

            else
            {
                OnCompleted?.Invoke();
            }
        }
        
        // ---------------------------------------------------------------------------------

    }
}