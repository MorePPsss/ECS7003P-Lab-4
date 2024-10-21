using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerShipController : MonoBehaviour
{
    private Rigidbody rb;

    // Speed of the ship
    public float speed = 10f;

    // Boundary values for the game area
    public float xMin = -3f;
    public float xMax = 3f;
    public float yMin = -5f;
    public float yMax = 5f;

    // Tilt amount for lateral movement
    public float tilt = 30f;

    // Fire position
    public Transform firePosition;

    // Bolt prefab to instantiate 
    public GameObject boltPrefab;

    // Cooldown variables
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (InputManager.instance.fireAction.triggered && Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = InputManager.instance.moveAction.ReadValue<Vector2>();

        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.velocity = movement*speed;
        
        float clampedX = Mathf.Clamp(rb.position.x, xMin, xMax);
        float clampedY = Mathf.Clamp(rb.position.z, yMin, yMax);
        rb.position = new Vector3(clampedX, rb.position.y, clampedY);

        float tiltAmount = rb.velocity.x * tilt;
        rb.rotation = Quaternion.Euler(0f, 0f, tiltAmount);
    }
    private void Fire()
    {
        Instantiate(boltPrefab, firePosition.position, Quaternion.identity);
    }
}
