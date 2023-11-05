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
    public CustomerEmotion customerEmotion;
    public bool packageReceived;
    Package package;
    public bool orderReceived;
    CustomerBaseState currentCustomerState;
    CustomerIdle idleState;
    CustomerReceivePackage receivePackageState;
    CustomerRequestPackage requestPackageState;
    CustomerReturnPackage returnPackageState;
    CustomerAwaitingPackage waitingPackageState;

    public TextMeshProUGUI customerStateText;

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
    }
    void init()
    {
        idleState = new CustomerIdle();
        receivePackageState = new CustomerReceivePackage();
        requestPackageState = new CustomerRequestPackage();
        returnPackageState = new CustomerReturnPackage();

        customerName = "Bob Marley";

        EnterState(idleState);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RequestPackage();
        }
    }

    void RequestPackage()
    {
        EnterState(receivePackageState);
    }
    public void WaitForOrder()
    {
        EnterState(waitingPackageState);
    }
    public void EnterState(CustomerBaseState nextState)
    {
        currentCustomerState = nextState;
        nextState.EnterState(this);
        customerStateText.text = nextState.GetType().ToString();
    }
    public void CreatePakage()
    {
        GameObject package = Instantiate(packagePrefab, null, spawningPoint);
        package.GetComponent<Package>().SetupPackage(PackageType.NonPerrishable);
    }
}
