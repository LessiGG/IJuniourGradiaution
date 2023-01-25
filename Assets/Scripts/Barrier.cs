using Player;
using UnityEngine;
using Utils;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject _bricksParticles;
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();

        if (playerModifier != null)
        {
            playerModifier.HitBarrier();
            Destroy(gameObject);
            SpawnUtils.Spawn(_bricksParticles, transform.position);
        }
    }
}