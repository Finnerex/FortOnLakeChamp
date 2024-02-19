using System.Linq;
using Progression;
using UnityEngine;

namespace Utility
{
    public class ToggleObjectTrigger : Triggerable
    {
        [SerializeField] private GameObject toToggle;
    
        public override void Trigger()
        {
            toToggle.SetActive(!toToggle.activeSelf);
        }
    }
}