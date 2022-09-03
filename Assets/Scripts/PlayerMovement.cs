using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;
    Camera cam;
    private float health;

    private Vector2 movementInput;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        //movement
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput *= Time.deltaTime;

        rb.AddForce(movementInput * movementSpeed,ForceMode2D.Force);

        //look at mouse
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.right = new Vector3(mouse.x,mouse.y,transform.position.z) - transform.position;
    }
}
