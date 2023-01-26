using TMPro;
using UnityEngine;

namespace Coins
{
    [RequireComponent(typeof(CoinsHolder))]
    public class CoinsViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private CoinsHolder _coinsHolder;

        private void OnEnable()
        {
            _coinsHolder = GetComponent<CoinsHolder>();
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