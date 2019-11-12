using UnityEngine;
using System.Collections;
using System;

public class PlayerAnimations : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animationCharacter;
    private Rigidbody2D rb;

    private PlayerInputs playerInputs;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animationCharacter = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        playerInputs = GetComponent<PlayerInputs>();
    }

    void Update()
    {
        Flip();
        RunAnimation();
        JumpAnimation();
        CrouchAnimation();
    }

    void Flip()
    {
        if (playerInputs.moveHorizontal < 0)
        {
            sprite.flipX = true;
        } else if (playerInputs.moveHorizontal > 0)
        {
            sprite.flipX = false;
        }
    }

    void RunAnimation()
    {
        if (playerInputs.moveHorizontal != 0)
        {
            animationCharacter.SetBool("Run", true);
        } else
        {
            animationCharacter.SetBool("Run", false);
        }
    }

    void JumpAnimation()
    {
        if (playerInputs.jump || !playerInputs.floor)
        {
            animationCharacter.SetBool("Jump", true);
        } else
        {
            animationCharacter.SetBool("Jump", false);
        }
    }

    private void CrouchAnimation()
    {
        if (playerInputs.floor && playerInputs.moveVertical < 0)
        {
            animationCharacter.SetBool("Crouch", true);
        } else
        {
            animationCharacter.SetBool("Crouch", false);
        }
    }
}
