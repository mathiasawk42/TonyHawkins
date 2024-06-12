using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPCControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;  
    [SerializeField] private float jumpForce = 5f;  
    [SerializeField] private float lookSensitivity = 3f;  
    [SerializeField] private float interactRange = 2f;  // range for interacting with objects
    [SerializeField] private LayerMask interactMask;  // layer mask for interactable objects

    private Rigidbody rb;
    private Camera cam;
    private Vector3 moveDirection;
    private float mouseX, mouseY;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;  
        Cursor.visible = false;  
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        mouseX += Input.GetAxis("Mouse X") * lookSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * lookSensitivity;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);  

        moveDirection = (transform.right * moveX + transform.forward * moveZ).normalized;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Draw a ray from the center of the screen for a short distance
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.green, 0.1f);

        // Check for interactable objects within range
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("PEW PEW");
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactRange))
            {
                Debug.Log("HIT!"+hit.collider);
            }
            if (Physics.Raycast(ray, out hit, interactRange, interactMask))
            {
                if (hit.collider.CompareTag("Objective"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

        transform.eulerAngles = new Vector3(0f, mouseX, 0f);
        cam.transform.eulerAngles = new Vector3(mouseY, mouseX, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
