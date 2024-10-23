using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour
{
    private Rigidbody rb;
    public float maxSpeed = 400f;
    public float minSpeed = 100f;
    private float speed;
    public int minAngularSpeed = 1;
    public int maxAngularSpeed = 4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "bolt_quad")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularDrag = 0;
        rb.angularVelocity = new Vector3(Random.Range(minAngularSpeed, maxAngularSpeed),
                                         Random.Range(minAngularSpeed, maxAngularSpeed),
                                         Random.Range(minAngularSpeed, maxAngularSpeed));
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        rb.velocity = Vector3.back * speed * Time.deltaTime;
    }
}
