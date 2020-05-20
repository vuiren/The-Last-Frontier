using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontal = transform.right * Input.GetAxis("Horizontal");
        rb.velocity = horizontal * moveSpeed;
    }
}
