using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    public GameObject e;

    public float moveSpeed = 10;
    
    private bool facingright = true;
    private float moveDirection;
    private Rigidbody2D rb;

    private Vector2 boxSize = new Vector2(1f, 1f);

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }

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


    public void OpenInteractableIcon()
    {
        e.SetActive(true);
    }
    public void CloseInteractableIcon()
    {
        e.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if(hits.Length > 0)
        {
            foreach (RaycastHit2D rc in hits)
            {
                if(rc.IsInteractable())
                {
                    rc.Interact();
                    return;
                }
            }
        }
    }
}
