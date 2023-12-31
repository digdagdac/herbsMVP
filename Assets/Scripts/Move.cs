using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private HerbArray targetPoint;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public float speed = 5f;
    public float dash = 5f;

    public Herbs carriedHerb;

    private Vector2 dir = Vector2.zero;

    
    
    void Start()
    {   
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();

        if (Input.GetMouseButtonDown(0))
        {
            if (carriedHerb !=null)
            {
                carriedHerb.isMoving = false;
                carriedHerb.PickUp();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
           
            if (carriedHerb != null)
            {
                
                carriedHerb.DropHerb();

                Debug.Log("³õ±â");
            }
        }

    }
    void HandleMovementInput()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        if (dir.x < 0)
        {
            sp.flipX = false;
        }
        else if (dir.x > 0)
        {
            sp.flipX = true;
        }
        if (dir != Vector2.zero)
        {
            rb.velocity = dir * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
            Herbs collidedHerb = collision.gameObject.GetComponent<Herbs>();
            if (collidedHerb != null)
            {
                carriedHerb = collidedHerb;
            }
        
    }
}
