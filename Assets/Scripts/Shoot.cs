using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] Text text;
    private PickubableObject _musket;
    private bool _canShoot = true; // Variable to control shooting cooldown

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody musketBall;

    void Start()
    {
        _musket = GetComponent<PickubableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _musket.IsHeld && _canShoot)
        {
            // Trigger the shooting coroutine
            StartCoroutine(ShootCoroutine());

            // Prevent shooting until the cooldown is over
            _canShoot = false;
        }
    }

    // Coroutine for the shooting logic
    private IEnumerator ShootCoroutine()
    {
        Transform playerTransform = transform;
        Vector3 playerForward = -playerTransform.forward;
        Vector3 ballOffset = playerForward * 1.5f + playerTransform.up * 1.35f;
        Instantiate(musketBall, playerTransform.position + ballOffset, Quaternion.identity).velocity =
            (playerForward * speed);
        
        //enables reload text
        text.enabled = true;
        
        //garenteed 3 sec wait time
        yield return new WaitForSeconds(3f);
        
        //waits until 'r' is pressed
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.R));
        
        //gets rid of reload text
        text.enabled = false;
        
        // Allow shooting again
        _canShoot = true;
    }
}
