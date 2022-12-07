using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HOG
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private UiItem prefab;
        private TextMeshProUGUI _levelText;
        private GameManager _gameManager;

        private Dictionary<string, UiItem> _uiItems = new Dictionary<string, UiItem>();
        private void Awake()
        {
            _levelText = GetComponentInChildren<TextMeshProUGUI>();
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnlevelChanged += UpdateLevelText;
        }

        private void OnDestroy()
        {
            _gameManager.OnlevelChanged -= UpdateLevelText;
        }

        private void UpdateLevelText(int levelIndex)
        {
            _levelText.text = $"level: {levelIndex}";
        }

        public void GenerateList(Dictionary<string, GameItemData> dictionary)
        {
            _uiItems.Clear();
            foreach (string key in dictionary.Keys)
            {
                UiItem item = Instantiate(prefab, content);
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