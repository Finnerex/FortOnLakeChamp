using System;
using UnityEngine;

public class BreathController : MonoBehaviour
{
    
    [SerializeField] private ParticleSystem breath;
    [SerializeField] private PlayerController controller;

    [SerializeField] private float breathDelaySeconds;
    private float _currentBreathTimeSeconds;

    // Update is called once per frame
    void Update()
    {
        _currentBreathTimeSeconds += Time.deltaTime;

        if (controller.StaminaSecondsLeft < controller.GetMaxStamina && !(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
                                                                     && _currentBreathTimeSeconds >= breathDelaySeconds)
        {
            Breathe();
            _currentBreathTimeSeconds = 0;
        }
    }
    
    private void Breathe()
    {
        breath.Play();
        // play a sound in here eventually and maybe stamina???
    }
}
