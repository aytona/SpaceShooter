using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    Rigidbody rb;
    public float tumble = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}