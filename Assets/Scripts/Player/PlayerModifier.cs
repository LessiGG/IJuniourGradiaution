using UnityEngine;
using Utility;

namespace Player
{
    public class PlayerModifier : MonoBehaviour
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;

        [SerializeField] private int _heightDecreaseValue = 50;
        [SerializeField] private int _widthDecreaseValue = 50;

        [SerializeField] private Renderer _renderer;
        [SerializeField] private SoundPlayer _soundPlayer;
    
        [SerializeField] private Transform _topSpine;
        [SerializeField] private Transform _bottomSpine;

        [SerializeField] private Transform _colliderTransform;

        private Progress _progress;
        private WindowDisplayer _windowDisplayer;
    
        private static readonly int PushValue = Shader.PropertyToID("_PushValue");

        private const float Widthmultiplier = 0.0005f;
        private const float HeightMultiplier = 0.01f;
        private const float SpinesDistance = 0.17f;
        private const float CharacterHeight = 1.84f;


        private void Awake()
        {
            _progress = FindObjectOfType<Progress>();
            _windowDisplayer = FindObjectOfType<WindowDisplayer>();
        }

        private void Start()
        {
            SetHeight(_progress.Height);
            SetWidth(_progress.Width);
        }

        private void Update()
        {
            CalculateHeight();
        }

        public void ChangeWidth(int value)
        {
            _width += value;
            UpdateWidth();
            PlayPumpSound();
        }
    
        public void ChangeHeight(int value)
        {
            _height += value;
            PlayPumpSound();
        }

        public void SetWidth(int value)
        {
            _width = value;
            UpdateWidth();
        }
    
        public void SetHeight(int value)
        {
            _height = value;
        }

        public void HitBarrier()
        {
            if (_height > 0)
            {
                _height -= _heightDecreaseValue;
            }
            else if (_width > 0)
            {
                _width -= _widthDecreaseValue;
                UpdateWidth();
            }
            else
            {
                Die();
            }
        }

        private void CalculateHeight()
        {
            float offsetY = _height * HeightMultiplier + SpinesDistance;
            _topSpine.position = _bottomSpine.position + new Vector3(0, offsetY, 0);

            float colliderHeight = CharacterHeight + _height * HeightMultiplier;
            _colliderTransform.localScale = new Vector3(1, colliderHeight, 1);
        }

        private void UpdateWidth()
        {
            _renderer.material.SetFloat(PushValue, _width * Widthmultiplier);
        }

        private void Die()
        {
            Destroy(gameObject);
            _windowDisplayer.ShowFinishWindow();
        }

        private void PlayPumpSound()
        {
            _soundPlayer.Play();
        }
    }
}