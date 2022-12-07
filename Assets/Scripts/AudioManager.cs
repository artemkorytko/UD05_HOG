using System;
using UnityEngine;

namespace HOG
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                _audioSource.Play();
                _audioSource.PlayOneShot(clip);
        }
    }
}