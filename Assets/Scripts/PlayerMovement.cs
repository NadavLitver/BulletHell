using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : LiveBody
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1f;
    private PlayerAnimation playerAnim;

    private void Awake()
    {
        playerAnim = FindObjectOfType<PlayerAnimation>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
    }
    private void FixedUpdate()
    {
       
        rb.MovePosition(rb.position + new Vector2(moveH, moveV) * Time.fixedDeltaTime);//OPTIONAL rb.MovePosition();
        Vector2 direction = new Vector2(moveH, moveV);
       // playerAnim.SetDirection(direction);
    }



}
