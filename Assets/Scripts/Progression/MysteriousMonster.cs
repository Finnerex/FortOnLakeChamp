using System;
using UnityEngine;

namespace Progression
{
    public class MysteriousMonster : MonoBehaviour
    {

        [SerializeField] private Transform player;
        private float speed = -0.5f;
        
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (StageManager.CurrentStage != GameStage.MonsterApproach)
                return;

            speed += 0.001f;
            
            if (speed < 0)
                return;

            Transform t = transform;
            Vector3 position = t.position;

            position += (player.position - position).normalized * (speed * 0.1f);

            t.position = position;
        }
    }
}