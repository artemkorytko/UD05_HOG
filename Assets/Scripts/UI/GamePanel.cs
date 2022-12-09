using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
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
        }

        private void Start()
        {
            _gameManager.OnNextLevelIndex += OnNextLevelIndex;
            _numberText.text = $"Level: {_gameManager.LevelIndex}";
        }

        private void OnDestroy()
        {
            _gameManager.OnNextLevelIndex -= OnNextLevelIndex;
        }

        private void OnNextLevelIndex(int index) 
        {
            _numberText.text = $"Level: {index}";
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