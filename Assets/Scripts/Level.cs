using System;
using Unity.VisualScripting;
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
                OnCompleted?.Invoke();
            }
        }
        
    }
}