using Coins;
using Player;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private int _price = 20;
    [SerializeField] private int _heightIncreaseValue = 25;
    [SerializeField] private int _widthIncreaseValue = 25;

    private PlayerModifier _playerModifier;
    private Progress _progress;

    private void Start()
    {
        _playerModifier = FindObjectOfType<PlayerModifier>();
        _progress = FindObjectOfType<Progress>();
    }

    public void BuyWidth()
    {
        if (HaveEnoughMoney)
        {
            Buy();
            _progress.AddWidth(_widthIncreaseValue);
            _playerModifier.SetWidth(_progress.Width);
        }
    }

    public void BuyHeight()
    {
        if (HaveEnoughMoney)
        {
            Buy();
            _progress.AddHeight(_heightIncreaseValue);
            _playerModifier.SetHeight(_progress.Height);
        }
    }

    private void Buy()
    {
        _coinManager.ReduceMoneyCount(_price);
        _progress.SetCoinsCount(_coinManager.CoinsCount);
    }
    
    private bool HaveEnoughMoney => _coinManager.CoinsCount >= _price;
}