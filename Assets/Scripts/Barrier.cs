using Player;
using UnityEngine;
using Utils;

public class Barrier : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bricksParticles;
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();

        if (playerModifier != null)
        {
            playerModifier.HitBarrier();
            Destroy(gameObject);
            SpawnUtils.SpawnParticle(_bricksParticles.gameObject, transform.position);
        }
    }
}