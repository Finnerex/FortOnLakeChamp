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
        Vector3 musketBallVector = Vector3.zero;
        
        if (Input.GetMouseButton(0) && _musket.IsHeld)
        {
            Instantiate(musketBall, transform.position, Quaternion.identity);
            musketBall.velocity = transform.forward * 10;
        }
    }
}
