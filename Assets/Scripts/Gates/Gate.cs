using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Gates
{
    [RequireComponent(typeof(GateAppearance))]
    public class Gate : MonoBehaviour
    {
        [SerializeField] private int _value;
        [SerializeField] private GateType _gateType;
    
        private GateAppearance _appearance;

        public event UnityAction GatePassed; 

        private void OnValidate()
        {
            if (_appearance == null)
                _appearance = GetComponent<GateAppearance>();
        
            _appearance.UpdateVisual(_gateType, _value);
        }

        private void OnTriggerEnter(Collider other)
        {
            PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        
            if (playerModifier != null)
            {
                switch (_gateType)
                {
                    case GateType.Height:
                        playerModifier.ChangeHeight(_value);
                        break;
                    case GateType.Width:
                        playerModifier.ChangeWidth(_value);
                        break;
                }
            
                GatePassed?.Invoke();
            }
        }
    }
}