using UnityEngine;
using Utils;

namespace Coins
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private ParticleSystem _coinParticle;
        [SerializeField] private CoinsHolder _coinsHolder;
        
        private void Update()
        {
            transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            _coinsHolder.AddCoin();
            Destroy(gameObject);
            SpawnUtils.SpawnParticle(_coinParticle.gameObject, transform.position);
        }
    }
}