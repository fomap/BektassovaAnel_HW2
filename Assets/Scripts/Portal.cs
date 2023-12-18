using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Portal : MonoBehaviour
{
    private Transform destination;
    public bool _isOrange;
    public float distance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        if(_isOrange == false)
        {
            destination = GameObject.FindGameObjectWithTag("Orangeportal").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("Blueportal").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(Vector2.Distance(transform.position, collider.transform.position) > distance)
        {
            collider.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
    }
}
