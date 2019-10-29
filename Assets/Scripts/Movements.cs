using UnityEngine;

public class Movements : MonoBehaviour {

    [SerializeField] private float speed = 10;
    [SerializeField] private float strengthJump = 10;
    [SerializeField] private bool floor = true;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private float move;
    private bool jumping;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        move = Input.GetAxis("Horizontal");

        if (floor && Input.GetKeyDown(KeyCode.Space)) {
            jumping = true;

        } else {
            jumping = false;

        }

        Flip();
        RunningAnimation();

    }

    private void FixedUpdate() {
        Move();

        if (jumping) {
            Jump();
            jumping = false;
        }

    }

    private void Jump() {
        rb.AddForce(new Vector2(0f, strengthJump), ForceMode2D.Impulse);

    }

    private void Move() {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

    }

    private void Flip() {
        if (move < 0) {
            sprite.flipX = true;

        } else if (move > 0) {
            sprite.flipX = false;

        }
    }

    private void RunningAnimation() {
        if (move > 0 || move < 0) {
            GetComponent<Animator>().SetBool("Running", true);

        } else {
            GetComponent<Animator>().SetBool("Running", false);
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            floor = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            floor = false;

        }
    }
}