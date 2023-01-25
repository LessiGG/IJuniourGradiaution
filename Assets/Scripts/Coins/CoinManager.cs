using TMPro;
using UnityEngine;

namespace Coins
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
    
        public int CoinsCount { get; private set; }

        private Progress _progress;

        private void Awake()
        {
            _progress = FindObjectOfType<Progress>();
        }

        private void Start()
        {
            CoinsCount = _progress.Coins;
            UpdateCoinsUI();
        }

        public void ReduceMoneyCount(int price)
        {
            CoinsCount -= price;
            UpdateCoinsUI();
        }

        public void AddCoin()
        {
            CoinsCount++;
            UpdateCoinsUI();
        }

        public void SaveProgress()
        {
            _progress.SetCoinsCount(CoinsCount);
        }

        private void UpdateCoinsUI()
        {
            _text.text = CoinsCount.ToString();
        }
    }
}