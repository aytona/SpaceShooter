using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour {

    Rigidbody rb;
    public float speed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }
}
