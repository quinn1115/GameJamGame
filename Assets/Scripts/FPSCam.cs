using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCam : MonoBehaviour
{
    public float mouseSensitivity;
    public float moveSpeed;
    public float jumpForce;
    public Transform head;
    public LayerMask mask;

    Rigidbody rb;
    float xRotation;
    bool onGround;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 65f);
        head.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
        rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed / 100) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed / 100));
        if (Input.GetKeyDown("space") && onGround)
        {
            rb.AddForce(transform.up * jumpForce * 10, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}