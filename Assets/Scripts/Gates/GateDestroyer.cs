using System.Collections.Generic;
using UnityEngine;

namespace Gates
{
    [RequireComponent(typeof(GatesHolder))]
    public class GateDestroyer : MonoBehaviour
    {
        private List<Gate> _gates;
        
        private void OnEnable()
        {
            _gates = GetComponent<GatesHolder>().GetGates();
            
            foreach (var gate in _gates)
                gate.GatePassed += OnGatePassed;
        }

        private void OnDisable()
        {
            foreach (var gate in _gates)
                gate.GatePassed -= OnGatePassed;
        }
        
        private void OnGatePassed()
        {
            foreach (var gate in _gates)
                Destroy(gate.gameObject);
        }
    }
}