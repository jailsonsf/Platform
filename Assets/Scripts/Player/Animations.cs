using UnityEngine;

public class Animations : MonoBehaviour {
    private Animator animationPlayer;

    private float move;
    
    private void Start() {
        animationPlayer = GetComponent<Animator>();

    }

    private void Update() {
        move = Input.GetAxis("Horizontal");

        running();
    }

    public void running() {
        if (move > 0 || move < 0) {
            animationPlayer.SetBool("Running", true);

        } else {
            animationPlayer.SetBool("Running", false);
            
        }
    }
}