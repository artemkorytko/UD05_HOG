using System;
using UnityEngine;

namespace HOG
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _winClip;
        
        private AudioSource _audioSource;
        private GameManager _gameManager;


        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Start()
        {
            _gameManager.OnWin += OnPlayAudioWin;
        }

        private void OnDestroy()
        {
            _gameManager.OnWin -= OnPlayAudioWin;
        }
        
        private void OnPlayAudioWin()
        {
            _audioSource.PlayOneShot(_winClip);
        }

     
    }
}