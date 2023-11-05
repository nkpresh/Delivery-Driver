using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    Color hasPackageColor = Color.green;
    [SerializeField]
    Color deliveredPackageColor = Color.white;
    [SerializeField]
    float destroyTime;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    // bool packagePickedup = false;
    float steerSpeed = 1;
    [SerializeField]
    float moveSpeed = 0.01f;

    float carHealth = 100f;
    float carNitro = 0;

    public int packageCapacity;
    int packageAmount = 0;
    void Start()
    {
        print(moveSpeed);
    }

    void Update()
    {
        // if (moveSpeed != 0)
        //     GetComponent<Rigidbody2D>().velocity = Vector2.up * moveSpeed * Time.deltaTime;

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        transform.Translate(0, yAxis * 10 * Time.deltaTime, 0);
        transform.Rotate(0, 0, -xAxis);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && CanLoadPackage())
        {

            Destroy(other.gameObject, 1);
            spriteRenderer.color = hasPackageColor;
            packageAmount++;
        }
        else if (other.tag == "Customer" && CanOffLoadPackage())
        {
            packageAmount--;
            Debug.Log("Package Delivered");
            if (!CanOffLoadPackage())
                spriteRenderer.color = deliveredPackageColor;
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        damageCar(10);
        Deccelerate(moveSpeed / 2);
    }

    bool CanLoadPackage()
    {
        return (packageAmount < packageCapacity);
    }
    bool CanOffLoadPackage()
    {
        return (packageAmount > 0);
    }

    public void Accelerate()
    {
        if (moveSpeed < 5000)
        {
            moveSpeed += 300;
        }
    }
    public void Deccelerate(float amount)
    {
        // if ((moveSpeed - amount) > -500)
        // {
        moveSpeed -= amount;
        // print("break" + moveSpeed);
        // }
        // else
        // {
        //     moveSpeed = 0;
        //     print("stop");
        // }
    }
    public void damageCar(float amount)
    {
        carHealth -= amount;
    }
}