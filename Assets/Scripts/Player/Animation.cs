using UnityEngine;

public class Animation : MonoBehaviour {
    private SpriteRenderer sprite;
    private Animator animationCharacter;

    private float move;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        animationCharacter = GetComponent<Animator>();

    }

    private void Update() {
        move = Input.GetAxis("Horizontal");

        Flip();
        RunAnimation();
    }

    private void RunAnimation() {
        if (move > 0 || move < 0) {
            animationCharacter.SetBool("Running", true);

        } else {
            animationCharacter.SetBool("Running", false);
            
        }
    }

    private void Flip() {
        if (move < 0) {
            sprite.flipX = true;

        } else if (move > 0) {
            sprite.flipX = false;

        }
    }
}