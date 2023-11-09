using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private PickubableObject _musket;
    
    private bool _needReload;
    [SerializeField] private float reloadTimeSeconds;
    private float _currentReloadTimeSeconds;

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody musketBall;

    void Start()
    {
        text.enabled = false;
        _musket = GetComponent<PickubableObject>();
        _currentReloadTimeSeconds = reloadTimeSeconds + 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && _musket.IsHeld && _currentReloadTimeSeconds >= reloadTimeSeconds && !_needReload)
        {
            // Trigger the shooting coroutine
            Transform playerTransform = transform;
            Vector3 playerForward = -playerTransform.forward;
            Vector3 ballOffset = playerForward * 1.5f + playerTransform.up * 1.35f;
            Instantiate(musketBall, playerTransform.position + ballOffset, Quaternion.identity).velocity =
                (playerForward * speed);
            
            _needReload = true;
            _currentReloadTimeSeconds = 0;
        }

        if (_needReload && Input.GetKeyDown(KeyCode.R))
        {
            text.enabled = true;
            _currentReloadTimeSeconds = 0;
        }

        if (_currentReloadTimeSeconds < reloadTimeSeconds)
            _currentReloadTimeSeconds += Time.deltaTime;
        else if (_needReload)
        {
            text.enabled = false;
            _needReload = false;
        }
    }
    
}
