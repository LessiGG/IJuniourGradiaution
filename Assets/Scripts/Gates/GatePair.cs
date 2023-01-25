using System.Collections.Generic;
using UnityEngine;

namespace Gates
{
    public class GatePair : MonoBehaviour
    {
        private readonly List<Gate> _gates = new List<Gate>();

        private void GetGates()
        {
            foreach (Transform child in transform)
            {
                var gate = child.GetComponent<Gate>();
                _gates.Add(gate);
            }
        }
        
        private void OnEnable()
        {
            GetGates();
            
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