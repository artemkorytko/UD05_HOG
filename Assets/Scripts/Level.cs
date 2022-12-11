using System;
using System.Collections.Generic;
using UnityEngine;

namespace HOG
{
    public class Level : MonoBehaviour
    {
        private GameItem[] _gameItems; //массив для хранения наших игровых объектов
        private int _itemsCount; //ск-ко игровых объектов было найдено

        public event Action OnCompleted;
        public event Action<string> OnItemFind;

        public void Initialize()
        {
            _gameItems = GetComponentsInChildren<GameItem>(); //componentS - т к массив!
            _itemsCount = _gameItems.Length;

            for (int i = 0; i < _gameItems.Length; i++)
            {
                _gameItems[i].Initialize();
                _gameItems[i].OnFind += OnFindItem;

            }


        }



        private void OnFindItem(string id)
        {
            _itemsCount--; //сначала вычитаем
            if (_itemsCount > 0) // потом сравниваем
            {
                OnItemFind?.Invoke(id);
            }
            else
            {
                OnItemFind?.Invoke(id);
                OnCompleted?.Invoke();
            }
        }

        public Dictionary<string, GameItemData> GetItemDictionary()
        {
            Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>();

            for (int i = 0; i < _gameItems.Length; i++)
            {
                GameItem item = _gameItems[i];
                string id = item.ID;
                
                if (itemsData.ContainsKey(_gameItems[i].ID))
                {
                    itemsData[_gameItems[i].ID].IncreaseAmount();
                }
                else
                {
                    itemsData.Add(id, new GameItemData(item.Sprite));
                }
            }
          

            return itemsData;
        }




    }
}