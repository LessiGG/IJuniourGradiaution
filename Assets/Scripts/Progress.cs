using UnityEngine;

public class Progress : MonoBehaviour
{
    public int Coins { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public void SetCoinsCount(int value)
    {
        Coins = value;
    }

    public void AddWidth(int value)
    {
        Width += value;
    }
    
    public void AddHeight(int value)
    {
        Height += value;
    }

    private void Awake()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }
}