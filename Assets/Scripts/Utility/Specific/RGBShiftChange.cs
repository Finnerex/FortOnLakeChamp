using System;
using UnityEngine;

namespace Utility.Specific
{
    public class RGBShiftChange : Triggerable
    {

        [SerializeField] private RGBShiftEffect rgbEffect;
        [SerializeField] private float amount;
        [SerializeField] private float speed;

        public override void Trigger()
        {
            rgbEffect.amount = amount;
            rgbEffect.speed = speed;
        }
        
    }
}