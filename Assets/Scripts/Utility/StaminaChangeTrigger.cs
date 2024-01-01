using System;
using System.Linq;
using Progression;
using UnityEngine;

namespace Utility
{
    public class StaminaChangeTrigger : MonoBehaviour
    {
        [SerializeField] private GameStage[] stages;
        [SerializeField] private bool staminaEnabled;
        [SerializeField] private PlayerController controller;
    
        private void OnTriggerEnter(Collider other)
        {
            if (!stages.Contains(StageManager.CurrentStage) || other.GetComponent<PlayerController>() == null)
                return;

            controller.StaminaEnabled = staminaEnabled;

        }
    }
}