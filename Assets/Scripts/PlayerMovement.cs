using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : LiveBody
{
    [HideInInspector]
    public Rigidbody2D rb;

    public bool canMove;

    private float moveH, moveV;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private PlayerShooter playershoot;
    [SerializeField]
  


    private PlayerAnimation playerAnim;
    internal bool isTeleport;

    private void Awake()
    {
        canMove = true;
        playerAnim = FindObjectOfType<PlayerAnimation>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (canMove)
        {
            moveH = Input.GetAxis("Horizontal") * moveSpeed;
            moveV = Input.GetAxis("Vertical") * moveSpeed;
        }
       
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        StartCoroutine(SetPlayerHealthBar.SetHP(hp));
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + new Vector2(moveH, moveV) * Time.fixedDeltaTime);
        }
        if (isTeleport)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, playershoot.curTelePos, playershoot.teleSpeed * Time.deltaTime));
            if (Vector2.Distance(rb.position, playershoot.telePoint.position) < 0.5f)
            {
                isTeleport = false;
               
            }
        }
    }
   
}
