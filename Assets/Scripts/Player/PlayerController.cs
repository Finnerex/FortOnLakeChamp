using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    
    private CharacterController _cc;
    [SerializeField] private float walkSpeed = 3;
    [SerializeField] private float sprintMultiplier = 2;

    [SerializeField] private float maxStaminaTimeSeconds = 10;
    public float GetMaxStamina => maxStaminaTimeSeconds;
    public float StaminaSecondsLeft { get; private set; }

    public bool MovementLocked { get; set; }
    public bool StaminaEnabled { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = transform;
        Vector3 direction = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
            direction = playerTransform.forward;

        if (Input.GetKey(KeyCode.S))
            direction -= playerTransform.forward;

        if (Input.GetKey(KeyCode.D))
            direction += playerTransform.right;

        if (Input.GetKey(KeyCode.A))
            direction -= playerTransform.right;

        // Sprint when moving forward and pressing shift
        // float speed = walkSpeed * (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) ? sprintMultiplier : 1);

        float speed = walkSpeed;
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && (StaminaSecondsLeft > 0 || !StaminaEnabled))
        {
            speed *= sprintMultiplier;
            StaminaSecondsLeft -= Time.deltaTime;
        }
        else if (StaminaSecondsLeft < maxStaminaTimeSeconds && !(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)))
            StaminaSecondsLeft += Time.deltaTime / 2;

        _cc.SimpleMove(MovementLocked ?  Vector3.zero : direction.normalized * speed);

    }
    
}
