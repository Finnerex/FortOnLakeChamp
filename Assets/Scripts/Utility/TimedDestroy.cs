using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{

    [SerializeField] private float destroyTimeSeconds = 1;
    private float _currentTimeSeconds;
    

    // Update is called once per frame
    void Update()
    {
        _currentTimeSeconds += Time.deltaTime;
        
        if (_currentTimeSeconds >= destroyTimeSeconds)
            Destroy(gameObject);
        
    }
}
