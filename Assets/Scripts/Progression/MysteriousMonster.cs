using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

namespace Progression
{
    public class MysteriousMonster : MonoBehaviour
    {

        [SerializeField] private Transform player;
        // [SerializeField] private CharacterController controller;
        [SerializeField] private Rigidbody body;
        [SerializeField] private float speed = 0.5f;
        [SerializeField] private float bias = 0.2f; // smaller bias : lower tendency to point to player
        [SerializeField] private float yawSpeed = 0.1f;
        [SerializeField] private float directionChangeIntervalSeconds = 2;

        private float _currentIntervalSeconds;
        private int _yawTarget;
        private Vector3 _directionTarget;
        private float _yawDiff;
        private readonly Random _rand = new Random();

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (StageManager.CurrentStage != GameStage.MonsterApproach)
                return;

            Transform t = transform;
            Vector3 forward = t.forward;

            float currentYawDiff = Vector3.SignedAngle(forward, _directionTarget, Vector3.up);
            
            if (Math.Abs(currentYawDiff) > 0.1f)
                t.Rotate(t.up, _yawDiff * yawSpeed);

            // controller.SimpleMove(forward * speed);
            
            if (_currentIntervalSeconds < directionChangeIntervalSeconds)
            {
                _currentIntervalSeconds += Time.deltaTime;
                return;
            }

            _currentIntervalSeconds = 0;

            Vector3 toPlayer = player.position - t.position;
            toPlayer.y = 0;
            int yawToPlayer = (int)(Vector3.SignedAngle(t.forward, toPlayer, Vector3.up) * -bias);
            
            _yawTarget = _rand.Next(-30 - yawToPlayer, 30 - yawToPlayer);
            _directionTarget = Quaternion.Euler(0, _yawTarget, 0) * forward;

            _yawDiff = Vector3.SignedAngle(forward, _directionTarget, Vector3.up);

        }

        private void FixedUpdate()
        {
            if (StageManager.CurrentStage != GameStage.MonsterApproach)
                return;
            
            body.MovePosition(body.position + transform.forward * speed);
        }


        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.name.Contains("palisade")) // strings are fo sho not the best way of doing this
                return;
            
            Debug.Log("You lose!!!!");
            // idk probably do a jumpscare here eventually and reset player
        }
        
    }
}