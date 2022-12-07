using System;
using System.Collections.Generic;
using UnityEngine;

namespace HOG
{
    public class Level : MonoBehaviour
    {
        private GameItem[] _gameItems;
        private int _itemsCount;

        public event Action OnCompleted;
        public event Action<string> OnItemFind;
        
        public void Initialize()
        {
            _gameItems = GetComponentsInChildren<GameItem>();
            _itemsCount = _gameItems.Length;

            for (int i = 0; i < _gameItems.Length; i++)
            {
                _gameItems[i].Initialize();
                _gameItems[i].OnFind += OnFindItem;

            }
        }
        
        private void OnFindItem(string id)
        {
            if (--_itemsCount > 0)
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
            //
            //for (int i = 0; i < _gameItems.Length; i++)
            //{
            //    GameItem item = _gameItems[i];
            //    string id = item.ID;
            //    
            //    if (itemsData.ContainsKey(id))
            //    {
            //        itemsData[id].IncreaseAmount();
            //    }
            //    else
            //    {
            //        itemsData.Add(id,new GameItemData(item.Sprite));
            //    }
            //}

            foreach (GameItem item in _gameItems)
            {
                string id = item.ID;
                if (itemsData.ContainsKey(id))
                {
                   itemsData[id].IncreaseAmount(); 
                }
            }

            return itemsData;
        }

    }
}