using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : LiveBody
{
    [HideInInspector]
    public Rigidbody2D rb;

    public bool canMove;

    private float moveH, moveV;

    public Vector2Int lastDirection;
    
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private PlayerShooter playershoot;
    internal bool isTeleport;
    private Vector2 movement;

    protected override void OnLiveBodyEnable()
    {
        base.OnLiveBodyEnable();
        lastDirection = new Vector2Int(0, -1);
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (canMove)
        {
            moveH = Input.GetAxis("Horizontal");
            moveV = Input.GetAxis("Vertical");
            animator.SetFloat("Hor", moveH);
            animator.SetFloat("Ver", moveV);
            movement = new Vector2(moveH, moveV) * moveSpeed;
            animator.SetFloat("Mag", movement.sqrMagnitude);
            SetLastDir();
            animator.SetFloat("LastHor", lastDirection.x);
            animator.SetFloat("LastVer", lastDirection.y);

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
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
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

    protected override void AfterTakeDamage()
    {
       
    }
    Vector2 Dir()
    {
        return new Vector2(moveH, moveV);
    }
    void SetLastDir()
    {
        if(moveH > 0)
        {
            lastDirection = new Vector2Int(1, 0);
        }else if ( moveH < 0)
        {
            lastDirection = new Vector2Int(-1, 0);

        }

        if (moveV > 0)
        {
            lastDirection = new Vector2Int(0, 1);
        }
        else if (moveV < 0)
        {
            lastDirection = new Vector2Int(0, -1);

        }
    } 
}
