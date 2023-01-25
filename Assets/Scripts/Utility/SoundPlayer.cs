using UnityEngine;

namespace Utility
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;
    
        private AudioSource _source;

        public void Play()
        {
            if (_source == null)
                _source = FindObjectOfType<AudioSource>();

            _source.PlayOneShot(_clip);
        }
    }
}