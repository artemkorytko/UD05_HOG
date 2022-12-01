using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling;
using UnityEngine;

namespace HOG
{
    public class LevelController : MonoBehaviour
    {
        private GameItem[] _gameItems;
        private int _itemsCount;

        public event Action OnCompleted;
        public event Action<string> OnItemFind;
        

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
    }
}
