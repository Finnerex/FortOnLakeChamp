using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
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

    private PlayerAudioController _audioController;
    private bool _wasWalking;
    private bool _wasSprinting;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _audioController = GetComponent<PlayerAudioController>();
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
        

        float speed = walkSpeed;

        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) &&
                           (StaminaSecondsLeft > 0 || !StaminaEnabled);
        
        if (isSprinting)
        {
            speed *= sprintMultiplier;
            StaminaSecondsLeft -= Time.deltaTime;
        }
        else if (StaminaSecondsLeft < maxStaminaTimeSeconds && !(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)))
            StaminaSecondsLeft += Time.deltaTime / 2;

        _cc.SimpleMove(MovementLocked ? Vector3.zero : direction.normalized * speed);

        // Audio
        bool isWalking = direction != Vector3.zero;
            
        if (!_wasSprinting && isSprinting)
        {
            _audioController.Loop("player_sprint", true);
            _audioController.Play("player_sprint", true);
        }
        else if (!_wasWalking && isWalking)
        {
            _audioController.Loop("player_walk", true);
            _audioController.Play("player_walk", true);
        }
        if (!isSprinting)
            _audioController.Loop("player_sprint", false);
        if (!isWalking || isSprinting)
            _audioController.Loop("player_walk", false);

        _wasSprinting = isSprinting;
        _wasWalking = isWalking && !_wasSprinting;

    }
    
}
