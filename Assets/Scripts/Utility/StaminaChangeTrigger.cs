using System;
using System.Linq;
using Progression;
using UnityEngine;

namespace Utility
{
    public class StaminaChangeTrigger : Triggerable
    {
        
        [SerializeField] private bool staminaEnabled;
        [SerializeField] private PlayerController controller;
    
        public override void Trigger()
        {
            controller.StaminaEnabled = staminaEnabled;
        }
    }
}