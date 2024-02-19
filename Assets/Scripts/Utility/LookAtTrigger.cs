using System.Linq;
using Player;
using Progression;
using UnityEngine;

namespace Utility
{
    public class LookAtTrigger : Triggerable
    {
        [SerializeField] private Transform objectToLookAt;
        [SerializeField] private float turnTimeSeconds = 2;

        [SerializeField] private PlayerCamera playerCamera;

        private Vector3 _lookPosition;

        private void Awake()
        {
            _lookPosition = objectToLookAt.position;
        }

        public override void Trigger()
        {
            playerCamera.LookAt(_lookPosition, turnTimeSeconds);
        }
    }
}