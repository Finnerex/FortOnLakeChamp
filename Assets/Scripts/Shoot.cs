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

    private const float BallOffsetX = 1.5f;
    private const float BallOffsetY = 1.35f;

    void Start()
    {
        text.enabled = false;
        _musket = GetComponent<PickubableObject>();
        _currentReloadTimeSeconds = reloadTimeSeconds + 1;
    }

    void Update()
    {
        HandleShooting();
        HandleReloading();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0) && _musket.IsHeld && _currentReloadTimeSeconds >= reloadTimeSeconds && !_needReload)
        {
            Transform playerTransform = transform;
            Vector3 playerForward = -playerTransform.forward;
            Vector3 ballOffset = playerForward * BallOffsetX + playerTransform.up * BallOffsetY;
            Instantiate(musketBall, playerTransform.position + ballOffset, Quaternion.identity).velocity = playerForward * speed;

            _needReload = true;
        }
    }

    private void HandleReloading()
    {
        if (_needReload && Input.GetKeyDown(KeyCode.R))
        {
            text.enabled = true;
            _currentReloadTimeSeconds = 0;
            _needReload = false;
        }

        if (_currentReloadTimeSeconds < reloadTimeSeconds)
            _currentReloadTimeSeconds += Time.deltaTime;
        else
            text.enabled = false;
    }
}
