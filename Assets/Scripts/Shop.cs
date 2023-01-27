using Coins;
using Player;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private int _price = 20;
    [SerializeField] private int _heightIncreaseValue = 25;
    [SerializeField] private int _widthIncreaseValue = 25;

    private PlayerModifier _playerModifier;
    private CoinsHolder _coinsHolder;
    private Progress _progress;

    private void Start()
    {
        _progress = FindObjectOfType<Progress>();
        _playerModifier = FindObjectOfType<PlayerModifier>();
        _coinsHolder = FindObjectOfType<CoinsHolder>();
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
        _coinsHolder.ReduceMoneyCount(_price);
        _progress.SetCoinsCount(_coinsHolder.CoinsCount);
    }
    
    private bool HaveEnoughMoney => _coinsHolder.CoinsCount >= _price;
}