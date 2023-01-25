using UnityEngine;
using Utils;

namespace Coins
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private GameObject _coinParticle;
    
        private CoinManager _coinManager;

        private void Start()
        {
            _coinManager = FindObjectOfType<CoinManager>();
        }

        private void Update()
        {
            transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            _coinManager.AddCoin();
            Destroy(gameObject);
            SpawnUtils.Spawn(_coinParticle, transform.position);
        }
    }
}