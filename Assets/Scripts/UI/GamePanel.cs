using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HOG
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private UiItem _prefab;
        [SerializeField] private TextMeshProUGUI _numberText;

        
        private Dictionary<string, UiItem> _uiItems = new Dictionary<string, UiItem>();
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _numberText.text = "Level: " + _gameManager.LevelIndex;
        }

        private void Start()
        {
            _gameManager.OnNextLevelIndex += OnNextLevelIndex;
        }

        private void OnDestroy()
        {
            _gameManager.OnNextLevelIndex -= OnNextLevelIndex;
        }

        private void OnNextLevelIndex(int obj) 
        {
            _numberText.text ="Level: " +  obj;
        }

        public void GenerateList(Dictionary<string, GameItemData> dictionary)
        {
            _uiItems.Clear();
            foreach (var key in dictionary.Keys)
            {
               UiItem item = Instantiate(_prefab, _content);
               item.SetSprite(dictionary[key].Sprite);
               item.SetCounter(dictionary[key].Amount); 
               _uiItems.Add(key, item);
            }
        }

        public void OnItemFind(string id)
        {
            if (_uiItems.ContainsKey(id))
            {
                _uiItems[id].Decrease();
            }
        }
    }
}