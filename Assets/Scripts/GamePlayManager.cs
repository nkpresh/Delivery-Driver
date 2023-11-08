using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    CustomerAiController customer;

    List<Package> packages;
    List<Package> deliveredPackages;
    public static GamePlayManager instance;
    private void Start()
    {
        instance = this;
        packages = new List<Package>();
    }
    private void Update()
    {

    }

    public void OnPackageOrder(Package package)
    {
        UiManager.instance.CreateNotification(package.customerName, "Store");
        // print("tell player that package order has been created");
        // customer.EnterIdleState();

    }

    public void CancelPackageOrder(Package package)
    {
        customer.EnterIdleState();
    }

    public void AcceptPackageOrder(Package package)
    {
        customer.WaitForOrder();
    }
}