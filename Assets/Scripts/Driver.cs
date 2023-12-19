using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    Color hasPackageColor = Color.green;
    [SerializeField]
    Color deliveredPackageColor = Color.white;
    [SerializeField]
    float destroyTime;

    // [SerializeField]
    // SpriteRenderer spriteRenderer;
    [SerializeField]
    float steerSpeed = 1;
    [SerializeField]
    float moveSpeed = 0.01f;
    float carHealth = 100f;
    float maxCarHealth = 100F;
    float carNitro = 0;

    public int packageCapacity;
    void Start()
    {
        updateCarHealthUi();
    }

    void Update()
    {
        // print(moveSpeed);
        // float yAxis = Input.GetAxis("Vertical");
        // transform.Translate(0, yAxis * 10 * Time.deltaTime, 0);
    }
    private void FixedUpdate()
    {
        Move();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Package")
        {
            if (GamePlayManager.instance.GetSelectedPackages().Count < packageCapacity)
            {
                if (other.GetComponent<Package>() != null)
                {
                    other.GetComponent<Package>().PickupPackage(this.transform);
                    other.transform.parent = this.transform;
                    // spriteRenderer.color = hasPackageColor;
                }
            }
        }
        else if (other.tag == "Customer")
        {
            if (GamePlayManager.instance.GetSelectedPackages().Count > 0)
            {
                if (other.GetComponent<CustomerAiController>() != null)
                {
                    print("working fine");
                    CustomerAiController customer = other.GetComponent<CustomerAiController>();
                    customer.OnPackageRecieved();
                    // other.transform.parent = this.transform;
                    // spriteRenderer.color = deliveredPackageColor;
                }
            }
        }
        GamePlayManager.instance.UpdatePackageData();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        damageCar(moveSpeed / 3);
        Deccelerate(moveSpeed + 3);
    }

    public void OnAccelerateButton()
    {
        Accelerate(5F);
    }

    public void OnDeccelerateButon()
    {
        Deccelerate(1F);
    }
    public void Accelerate(float amount)
    {
        if (moveSpeed < 30)
        {
            moveSpeed += amount;
        }
    }
    public void Deccelerate(float amount)
    {
        if (moveSpeed > -20)
        {
            moveSpeed -= amount;
        }
    }

    public void damageCar(float amount)
    {
        print(moveSpeed);
        if (moveSpeed > 15)
            carHealth -= amount;
        if (carHealth <= 0)
        {
            GamePlayManager.instance.OnGameOver(GameOverResult.Defeat);
        }
        updateCarHealthUi();
    }
    void Move()
    {
        float Ydir = Input.GetAxis("Vertical");
        if (Ydir != 0)
        {
            moveSpeed += Ydir;
            moveSpeed = Mathf.Clamp(moveSpeed, -30, 30);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, 1.5f * Time.deltaTime);
        }

        float moveY = moveSpeed * Time.deltaTime;
        transform.Translate(0, moveY, 0);

        float xAxis = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -xAxis);

    }
    void updateCarHealthUi()
    {
        float healthValue = carHealth / maxCarHealth;
        UiManager.instance.UpdateCarHealthProgress(healthValue);
    }
    public void BoostNitro()
    {

    }
}