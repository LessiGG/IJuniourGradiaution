using UnityEngine;

namespace Utils
{
    public class SpawnUtils
    {
        private const string ContainerName = "###SPAWNED###";

        public static void SpawnParticle(GameObject particle, Vector3 position, string containerName = ContainerName)
        {
            var container = GameObject.Find(containerName);
            
            if (container == null)
                container = new GameObject(containerName);
            
            Object.Instantiate(particle, position, Quaternion.identity, container.transform);
        }
    }
}