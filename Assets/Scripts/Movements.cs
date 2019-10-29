using UnityEngine;

public class Movements : MonoBehaviour {

    [SerializeField] private float speed = 10;
    [SerializeField] private float strengthJump = 10;
    [SerializeField] private bool floor = true;
    private float move;
    private void Start() {
        
    }

    private void FixedUpdate() {
        Move();
        Flip();
        RunAnimation();

    }

    private void Move() {
        move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(speed * move * Time.deltaTime, 0, 0);

    }

    private void Flip() {
        if (move < 0) {
            GetComponent<SpriteRenderer>().flipX = true;

        } else if (move > 0) {
            GetComponent<SpriteRenderer>().flipX = false;

        }
    }

    private void RunAnimation() {
        if (move > 0 || move < 0) {
            GetComponent<Animator>().SetBool("Run", true);

        } else {
            GetComponent<Animator>().SetBool("Run", false);
            
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