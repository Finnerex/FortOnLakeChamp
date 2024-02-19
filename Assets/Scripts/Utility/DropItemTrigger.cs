using UnityEngine;

namespace Utility
{
    public class DropItemTrigger : Triggerable
    {
        [SerializeField] private PickubableObject toDrop;
        
        public override void Trigger()
        {
            toDrop.Throw(Vector3.zero);
        }
    }
}