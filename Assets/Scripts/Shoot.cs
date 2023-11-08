using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private PickubableObject _musket;
    [SerializeField] private Rigidbody musketBall;

    void Start()
    {
        _musket = GetComponent<PickubableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = transform;
        
        if (Input.GetMouseButtonDown(0) && _musket.IsHeld)
        {
            Instantiate(musketBall, playerTransform.position, Quaternion.identity);
            musketBall.velocity = playerTransform.forward * 10;
        }
    }
}
