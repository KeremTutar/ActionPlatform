using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed=8f;
    private float jumpingPower = 32f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rgb2d;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); 

        if(Input.GetButtonDown("Jump")&& isGrounded())
        {
            rgb2d.velocity = new Vector2(rgb2d.velocity.x, jumpingPower);
        }
        if(Input.GetButtonDown("Jump")&& rgb2d.velocity.y>0f)
        {
            rgb2d.velocity = new Vector2(rgb2d.velocity.x, rgb2d.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rgb2d.velocity = new Vector2(horizontal * speed, rgb2d.velocity.y);

        
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }
   
}
