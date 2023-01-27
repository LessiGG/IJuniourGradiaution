using TMPro;
using UnityEngine;

namespace Coins
{
    public class CoinsViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private CoinsHolder _coinsHolder;

        private void OnEnable()
        {
            _coinsHolder = FindObjectOfType<CoinsHolder>();
            _coinsHolder.OnCoinsChanged += UpdateCoinsUI;
        }

        private void OnDisable()
        {
            _coinsHolder.OnCoinsChanged -= UpdateCoinsUI;
        }

        private void UpdateCoinsUI()
        {
            _text.text = _coinsHolder.CoinsCount.ToString();
        }
    }
}