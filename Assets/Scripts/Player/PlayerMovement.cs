using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 8;
    [SerializeField] private float strengthJump = 20;

    private Rigidbody2D rb;

    private PlayerInputs playerInputs;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        playerInputs = GetComponent<PlayerInputs>();
    }

    void FixedUpdate()
    {
        Run();
        Jump();
    }

    void Run()
    {
        rb.velocity = new Vector2(playerInputs.moveHorizontal * speed, rb.velocity.y);
    }

    void Jump()
    {
        if (playerInputs.jump)
        {
            rb.AddForce(new Vector2(0f, strengthJump), ForceMode2D.Impulse);
        }
    }
}
