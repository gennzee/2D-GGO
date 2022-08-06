using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private AttackDetails attackDetails;

    private float speed;
    private float travelDistance;
    private float xStartPosition;

    private bool isGravityOn;
    private bool hasHitGround;

    private Rigidbody2D rigid;

    [SerializeField]
    private float gravity;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private Transform damagePosition;
    [SerializeField]
    private float damageRadius;

    private void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0f;
        rigid.velocity = this.transform.right * speed;

        xStartPosition = transform.position.x;
        isGravityOn = false;
    }

    public void FireProjectile(float speed, float travelDistance, float damageAmount)
    {
        this.speed = speed;
        this.travelDistance = travelDistance;
        this.attackDetails.damageAmount = damageAmount;
    }

    private void Update()
    {
        if (!hasHitGround)
        {
            attackDetails.position = this.transform.position;

            if (isGravityOn)
            {
                float angel = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.AngleAxis(angel, Vector3.forward);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!hasHitGround)
        {

            Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

            if (damageHit)
            {
                //TODO: do damage to player
                Destroy(this.gameObject);
            }

            if (groundHit)
            {
                hasHitGround = true;
                rigid.gravityScale = 0f;
                rigid.velocity = Vector2.zero;
            }

            if (Mathf.Abs(xStartPosition - this.transform.position.x) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;
                rigid.gravityScale = gravity;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }
}
