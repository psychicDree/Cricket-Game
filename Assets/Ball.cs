using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private void Start()
    {
        lastFrameVelocity = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter Ball" );
        if (collision.gameObject.GetComponent<BatsmenRequest>())
        {
            Bounce(collision.contacts[0].normal);
        }
    }
    float x;
    float y;
    float z;
    Vector3 pos;
    private float bias = 0.5f;
    private Vector3 lastFrameVelocity;

    private void Bounce(Vector3 collisionNormal)
    {
        
        var bounceDirection = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        x = Random.Range(17,18);
        y = 0;
        z = Random.Range(25,46);
        pos = new Vector3(x, y, z);
        var directionToPlayer = pos - GetComponent<Rigidbody>().position;

        var direction = Vector3.Lerp(bounceDirection, directionToPlayer, bias);

        Debug.Log("Out Direction: " + direction);
        GetComponent<Rigidbody>().AddForce(direction * 25);
    }
}
