using System.Collections.Generic;
using UnityEngine;

namespace Gates
{
    public class GatesHolder : MonoBehaviour
    {
        private readonly List<Gate> _gates = new List<Gate>();
        
        public List<Gate> GetGates()
        {
            foreach (Transform child in transform)
            {
                var gate = child.GetComponent<Gate>();
                _gates.Add(gate);
            }

            return _gates;
        }
    }
}   