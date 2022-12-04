using System;
using TMPro;
using UnityEngine;

namespace HOG
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numberText;

        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _numberText.text = "Level: " + _gameManager.LevelIndex;
        }

        private void OnEnable()
        {
            _gameManager.NextLevelIndex += OnNextLevelIndex;
        }

        private void OnDisable()
        {
            _gameManager.NextLevelIndex -= OnNextLevelIndex;
        }

        private void OnNextLevelIndex(int obj)
        {
            _numberText.text ="Level: " +  obj;
        }
    }
}