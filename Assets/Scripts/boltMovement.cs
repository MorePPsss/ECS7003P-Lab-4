using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltMovement : MonoBehaviour
{
    public float speed = 20f;
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
