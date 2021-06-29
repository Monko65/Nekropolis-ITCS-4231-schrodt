using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float stratoHealth = 800f;
    public float spe = 15f;
    public float grav = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDis = 0.4f;
    public LayerMask groundMask;

    Vector3 velo;
    bool isGrounded;

    void Awake()
    {
        this.GetComponent<HealthSystem>().setHealth(stratoHealth);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDis, groundMask);

        if (isGrounded && velo.y < 0)
        {
            velo.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * spe * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velo.y = Mathf.Sqrt(jumpHeight * -2f * grav);
        }

        velo.y += grav * Time.deltaTime;

        controller.Move(velo * Time.deltaTime);
    }
}
