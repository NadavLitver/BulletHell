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

    [HideInInspector]
    public Direction myDir;

    private PlayerHitEffect m_hiteffect;

    protected override void OnLiveBodyEnable()
    {
        base.OnLiveBodyEnable();
        lastDirection = new Vector2Int(0, -1);
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        m_hiteffect = GetComponent<PlayerHitEffect>();
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
        StartCoroutine(SetPlayerHealthBar.SetHPCorou(hp));
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }
        if (isTeleport)
        {
            int h = new int();
            int v = new int();
            Vector2 destination = new Vector2();

            if (moveH > 0)
                h = 1;
            if(moveH < 0)
                h = -1;

            if (moveV > 0)
                v = 1;
            if (moveV < 0)
                v = -1;

            Vector2 movementWithoutSpeed = new Vector2(rb.position.x + h, rb.position.y + v);
            if (h > 0 || h < 0 || v > 0 || v < 0)
            {
                destination = movementWithoutSpeed;
            }else
            {
                destination = new Vector2(rb.position.x + lastDirection.x, rb.position.y + lastDirection.y);

            }


            rb.MovePosition(Vector2.MoveTowards(rb.position, destination, playershoot.teleSpeed * Time.deltaTime));
            if (Vector2.Distance(rb.position, destination) < 0.1f)
            {
                isTeleport = false;
            }
        }
    }

    protected override void AfterTakeDamage()
    {
        m_hiteffect.CallHitEffect();
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
            myDir = Direction.right;
        }else if ( moveH < 0)
        {
            lastDirection = new Vector2Int(-1, 0);
            myDir = Direction.left;
        }

        if (moveV > 0)
        {
            lastDirection = new Vector2Int(0, 1);
            myDir = Direction.back;
        }
        else if (moveV < 0)
        {
            lastDirection = new Vector2Int(0, -1);
            myDir = Direction.front;
        }
        
    }
    private IEnumerator PlayerKnockbackRoutine(Vector2 velocity)
    {
        canMove = false;
        rb.velocity = Vector2.zero;
        movement = Vector2.zero;
        rb.velocity = velocity;
        Debug.Log(velocity);
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector2.zero;
        canMove = true;
    }
    public void CallPlayerKnockback(Vector2 velocity)
    {
        StartCoroutine(PlayerKnockbackRoutine(velocity));
    }
}
