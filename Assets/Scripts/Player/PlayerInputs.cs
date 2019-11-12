using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour
{
    public bool floor = true;

    public bool jump = false;
    public float moveHorizontal = 0;
    public float moveVertical = 0;
    
    void Start()
    {

    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (floor && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        } else
        {
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            floor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            floor = false;
        }
    }
}
