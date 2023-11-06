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
        float speed = walkSpeed * (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) ? sprintMultiplier : 1);
        
        _cc.SimpleMove(direction.normalized * speed);

    }
    
}
