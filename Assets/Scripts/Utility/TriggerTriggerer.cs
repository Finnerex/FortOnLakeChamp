using System;
using System.Linq;
using Progression;
using UnityEngine;

namespace Utility
{
    public class TriggerTriggerer : MonoBehaviour
    {
        private Triggerable[] _triggerables;

        private void Awake()
        {
            _triggerables = GetComponents<Triggerable>();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>() == null)
                return;

            foreach (Triggerable triggerable in _triggerables)
            {
                if (triggerable.Stages.Contains(StageManager.CurrentStage))
                    triggerable.Trigger();
            }

        }
    }
}