using UnityEngine;

namespace HOG
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _winClip;
        
        private AudioSource _audioSource;

        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        
        public void PlayAudioWin()
        {
            _audioSource.PlayOneShot(_winClip);
        }

    }
}