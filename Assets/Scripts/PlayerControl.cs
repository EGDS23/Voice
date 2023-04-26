using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private float jumpSpeed = 5;

    private bool grounded;

    private Rigidbody rb;

    [SerializeField]
    private Transform bottomTransform;
    [SerializeField]
    private LayerMask FloorMask;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float sensX, sensY;
    private float mouseX, mouseY, xRotation, yRotation;
    private float multiplier = 0.01f;

    [SerializeField]
    private GameObject gameOverImage;
    [SerializeField]
    private GameObject winImage;


    [SerializeField] AudioSource source;
    [SerializeField] AudioSource hit;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        Movement();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < 0.1f)
        {
            source.Stop();
        }
        else if (!source.isPlaying)
        {
            source.Play();
        }
    }
    private void Movement()
    {
        grounded = Physics.CheckSphere(bottomTransform.position, 0.1f, FloorMask);
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        movement = transform.forward * movement.z + transform.right * movement.x;
        movement *= moveSpeed;
        movement.y = rb.velocity.y;
        rb.velocity = movement;
    }

    private void CameraRotation()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            //transform.position = spawnPoint.position;
            hit.Play();
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        gameOverImage.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        gameOverImage.SetActive(false);
        winImage.SetActive(false);
        transform.position = spawnPoint.position;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
