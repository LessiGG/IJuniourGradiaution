using UnityEngine;
using UnityEngine.Events;

namespace Coins
{
    public class CoinsHolder : MonoBehaviour
    {
        public event UnityAction OnCoinsChanged;
        
        private Progress _progress;

        public int CoinsCount { get; private set; }
        
        private void Awake()
        {
            _progress = FindObjectOfType<Progress>();
        }

        private void Start()
        {
            CoinsCount = _progress.Coins;
            InvokeCoinsChange();
        }

        public void ReduceMoneyCount(int price)
        {
            CoinsCount -= price;
            InvokeCoinsChange();
        }

        public void AddCoin()
        {
            CoinsCount++;
            InvokeCoinsChange();
        }

        public void SaveProgress()
        {
            _progress.SetCoinsCount(CoinsCount);
        }

        private void InvokeCoinsChange()
        {
            OnCoinsChanged?.Invoke();
        }
    }
}