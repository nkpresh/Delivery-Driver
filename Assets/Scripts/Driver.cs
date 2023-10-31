using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField]
    float boostSpeed = 25;
    [SerializeField]
    float slowSpeed = 20;
    [SerializeField]
    float steerSpeed = 1;
    [SerializeField]
    float moveSpeed = 0.01f;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        // float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;


        // transform.Rotate(0, 0, -steerAmount);
        // transform.Translate(0, moveAmount, 0);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("working");
        if (other.tag == "SpeedBoost")
        {
            Debug.Log("Speed Boosted");
            moveSpeed = +boostSpeed;
            Debug.Log(moveSpeed);

        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((moveSpeed - slowSpeed) <= 0) return;
        // Debug.Log("Slowed Down");
        moveSpeed -= slowSpeed;
        // Debug.Log(other.collider.name);
        Debug.Log(moveSpeed);
    }
}
