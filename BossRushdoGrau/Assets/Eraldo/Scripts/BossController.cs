using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigiBody2D;
    [SerializeField] Vector2 jumpForceDirection;
    [SerializeField, Min(0)] float raycastDistance;
    [SerializeField] LayerMask raycastLayer;
    [SerializeField] float jumpingInterval;
    float jumpingIntervalAtual;

    private void Awake()
    {
        jumpingIntervalAtual = jumpingInterval;
    }

    private void Update()
    {
        bool wallCheck = Physics2D.Raycast(transform.position, transform.right, raycastDistance, raycastLayer);

        if (wallCheck)
        {
            Flip();
        }
        if (jumpingIntervalAtual <= 0)
        {
            Jump();
            jumpingIntervalAtual = jumpingInterval;
        }
        else
        {
            jumpingIntervalAtual -= Time.deltaTime;
        }
    }
    [ContextMenu("Pulo")]
    void Jump()
    {
        Vector2 jumpDirection = new Vector2(transform.right.x * jumpForceDirection.x, jumpForceDirection.y);
        rigiBody2D.AddForce(jumpDirection);

    }

    void Flip()
    {
        float bossDirection = 0;
        if (transform.rotation.y == 0)
        {
            bossDirection = 180;
        }

        transform.rotation = Quaternion.Euler(0, bossDirection, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right * raycastDistance);
    }
}