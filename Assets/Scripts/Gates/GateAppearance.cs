using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gates
{
    public class GateAppearance : MonoBehaviour
    {
        [Header("Images")]
        [SerializeField] private Image _topImage;
        [SerializeField] private Image _bottomImage;

        [Header("Colors")]
        [SerializeField] private Color _positiveColor;
        [SerializeField] private Color _negativeColor;
        [Range(0, 1)]
        [SerializeField] private float _bottomImageAlpha = 0.5f;

        [Header("Labels")]
        [SerializeField] private GameObject _expandLabel;
        [SerializeField] private GameObject _shrinkLabel;
        [SerializeField] private GameObject _upLabel;
        [SerializeField] private GameObject _downLabel;
    
        [Space]
        [SerializeField] private TextMeshProUGUI _text;
    
        public void UpdateVisual(GateType gateType, int value)
        {
            UpdateGateColorAndValue(value);
            UpdateGateLabels(gateType, value);
        }

        private void UpdateGateLabels(GateType gateType, int value)
        {
            _expandLabel.SetActive(false);
            _shrinkLabel.SetActive(false);
            _upLabel.SetActive(false);
            _downLabel.SetActive(false);

            switch (gateType)
            {
                case GateType.Width:
                    if (value > 0)
                        _expandLabel.SetActive(true);
                    else
                        _shrinkLabel.SetActive(true);
                    break;
                case GateType.Height:
                    if (value > 0)
                        _upLabel.SetActive(true);
                    else
                        _downLabel.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateGateColorAndValue(int value)
        {
            string prefix = "";

            switch (value)
            {
                case > 0:
                    prefix = "+";
                    SetColor(_positiveColor);
                    break;
                case 0:
                    SetColor(Color.grey);
                    break;
                default:
                    SetColor(_negativeColor);
                    break;
            }
        
            _text.text = prefix + value;
        }

        private void SetColor(Color color)
        {
            _topImage.color = color;
            _bottomImage.color = new Color(color.r, color.g, color.b, _bottomImageAlpha);
        }
    }
}