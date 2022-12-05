using System;
using TMPro;
using UnityEngine;

namespace HOG
{
    public class GamePanel : MonoBehaviour
    {
        private TextMeshProUGUI _levelText;
        private GameManager _gameManager;

        private void Awake()
        {
            _levelText = GetComponentInChildren<TextMeshProUGUI>();
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnLevelChanged += UpdateLevelText;
        }

        private void OnDestroy()
        {
            _gameManager.OnLevelChanged -= UpdateLevelText;
        }

        private void UpdateLevelText(int levelIndex)
        {
            _levelText.text = $"Level: {levelIndex}";
        }
    }
}