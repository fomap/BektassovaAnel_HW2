using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestroyablePlatform : MonoBehaviour
{
    public float time;
    
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            // anim.Play("FailingRock");
            Destroy(gameObject, time);
        }
    }
}
