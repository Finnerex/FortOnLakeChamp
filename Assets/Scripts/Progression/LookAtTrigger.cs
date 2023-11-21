using System;
using System.Linq;
using UnityEngine;

namespace Progression
{
    public class LookAtTrigger : MonoBehaviour
    {
        [SerializeField] private Transform objectToLookAt;
        [SerializeField] private GameStage[] stages;
        [SerializeField] private float turnTimeSeconds = 2;

        [SerializeField] private PlayerCamera playerCamera;

        private Vector3 _lookPosition;

        private void Awake()
        {
            _lookPosition = objectToLookAt.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!stages.Contains(StageManager.CurrentStage) || other.GetComponent<PlayerController>() == null)
                return;
        
            playerCamera.LookAt(_lookPosition, turnTimeSeconds);
        }
    }
}