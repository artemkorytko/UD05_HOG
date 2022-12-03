using System;
using TMPro;
using UnityEngine;

namespace HOG
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numberText;

        private GameManager _gameManager;
        
        private void OnEnable()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _numberText.text = "Level " + _gameManager.LevelIndex;
        }

    }
}