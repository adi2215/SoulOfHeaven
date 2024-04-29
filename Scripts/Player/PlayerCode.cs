using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    private float horizontalValue;
    private float verticalValue;
    public float moveSpeed = 1f;
    public float movementSpeed;
    private Vector3 movementInput;

    private bool facingRight = false;
    public float reverse = 1f;
    private Vector2 shooTing;

    private Rigidbody2D rb;
    private Animator animator;
    public GameObject Aim;
    public MainData data;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        ProcessInputs();

        AimWork();

        if (shooTing.x > transform.position.x && !facingRight)
        {

            Flip();
            reverse = -1f;
            Debug.Log("R");
        }
        else if (shooTing.x < transform.position.x && facingRight)
        {

            Flip();
            reverse = 1f;
            Debug.Log("L");
        }

        if (movementInput != Vector3.zero)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void ProcessInputs()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        movementInput = new Vector3(horizontalValue, verticalValue);
        movementSpeed = Mathf.Clamp(movementInput.magnitude, 0.0f, 1.0f);

        movementInput.Normalize();
        if (movementInput != Vector3.zero)
        {
            transform.position += movementInput * moveSpeed * movementSpeed * Time.fixedDeltaTime;
            data.moveIdle = true;
            return;
        }
        data.moveIdle = false;
    }

    void AimWork()
    {
        shooTing = Aim.transform.position;
    }
}
