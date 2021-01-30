using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{

    public float moveSpeed = 10;
    
    private bool facingright = true;
    private float moveDirection;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        //Controls
        moveDirection = Input.GetAxis("Horizontal");
        //Player direction
        if (moveDirection > 0 && !facingright)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingright)
        {
            FlipCharacter();
        }
        //Animation
        
        //Movement
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

    void FlipCharacter()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
    }
}
