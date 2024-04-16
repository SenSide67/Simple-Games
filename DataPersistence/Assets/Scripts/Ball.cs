using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    private Vector3 velocity;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
      //  Debug.Log(Vector3.Dot(new Vector3(3, 3, 3), new Vector3(5, 5, 5)));
    }
    private void Update()
    {
        Debug.Log("maga:   " + velocity.magnitude);
    }

    private void OnCollisionExit(Collision other)
    {
         velocity = m_Rigidbody.velocity;
        
        Debug.Log("2" + velocity.normalized);
        Debug.Log("3" + velocity);


        //after a collision we accelerate a bit
        velocity += velocity.normalized * 0.01f;
        
        //check if we are not going totally vertically as this would lead to being stuck, we add a little vertical force
        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.1f)
        {
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        }

        //max velocity
        if (velocity.magnitude > 3.0f)
        {
            velocity = velocity.normalized * 3.0f;
        }

        m_Rigidbody.velocity = velocity;
    }
}
