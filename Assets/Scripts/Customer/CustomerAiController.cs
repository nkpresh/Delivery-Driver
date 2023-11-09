using System.Collections;
using System.Collections.Generic;
using Enums;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerAiController : MonoBehaviour
{
    [SerializeField]
    GameObject packagePrefab;
    [SerializeField]
    Transform spawningPoint;
    string customerName;
    public float waitTime;
    // public CustomerEmotion customerEmotion;
    public bool packageReceived;
    Package package;
    public bool orderReceived;
    CustomerBaseState currentCustomerState;
    CustomerIdle idleState;
    CustomerReceivePackage receivePackageState;
    CustomerRequestPackage requestPackageState;
    CustomerAwaitingPackage waitingPackageState;


    void Start()
    {
        init();
    }

    void Update()
    {
        if (currentCustomerState != null)
        {
            currentCustomerState.UpdateState(this);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RequestPackage();
        }
    }
    void init()
    {
        idleState = new CustomerIdle();
        receivePackageState = new CustomerReceivePackage();
        requestPackageState = new CustomerRequestPackage();

        customerName = "Bob Marley";

        EnterState(idleState);
    }

    void RequestPackage()
    {
        EnterState(requestPackageState);
    }
    public void WaitForOrder()
    {
        EnterState(waitingPackageState);
    }
    public void EnterIdleState()
    {
        EnterState(idleState);
    }
    public void EnterState(CustomerBaseState nextState)
    {
        currentCustomerState = nextState;
        nextState.EnterState(this);
        // customerStateText.text = nextState.GetType().ToString();
    }
    public void CreatePakageOrder()
    {
        Package package = Instantiate(packagePrefab, spawningPoint).GetComponent<Package>();
        package.SetupPackage(PackageType.Clothe, customerName, "Store");
        GamePlayManager.instance.CreatePackageOrder(package);
    }


}
