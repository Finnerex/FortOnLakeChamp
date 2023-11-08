using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    [SerializeField] private Rigidbody musketBall;
    
    // Update is called once per frame
    void Update()
    {
        Transform ballTransform = transform;
        Vector3 musketBallVector = Vector3.zero;
        
        if (Input.GetMouseButton(0))
        {
            Instantiate(musketBall);
            musketBallVector = ballTransform.forward * 10;
        }
        musketBall.velocity = musketBallVector;
    }
}
