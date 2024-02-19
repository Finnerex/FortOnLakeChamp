using System;
using UnityEngine;

namespace Progression
{
    public class MysteriousMonster : MonoBehaviour
    {

        [SerializeField] private Transform player;
        [SerializeField] private CharacterController controller;
        [SerializeField] private float _speed = 0.5f;
        
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (StageManager.CurrentStage != GameStage.MonsterApproach)
                return;

            // _speed += 0.001f;
            
            if (_speed < 0)
                return;

            Transform t = transform;
            Vector3 position = t.position;

            controller.Move(t.forward * _speed/*(player.position - position).normalized * (_speed * 0.1f)*/);
            controller.SimpleMove(Vector3.zero);

        }
    }
}