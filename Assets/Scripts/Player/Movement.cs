using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] private float speed = 8;
    [SerializeField] private float strengthJump = 20;
    [SerializeField] private bool floor;

    private Rigidbody2D rb;

    private float move;
    private bool isJumping;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update() {
        move = Input.GetAxis("Horizontal");

        if (floor && Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;

        } else {
            isJumping = false;

        }
    }

    private void FixedUpdate() {
        Run();

        if (isJumping) {
            Jump();

        }
        isJumping = false;

    }

    private void Run() {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

    }

    private void Jump() {
        rb.AddForce(new Vector2(0f, strengthJump), ForceMode2D.Impulse);

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