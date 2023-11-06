using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    CustomerAiController customer;

    public static GamePlayManager instance;
    private void Start()
    {
        instance = this;
    }
    private void Update()
    {

    }

    public void OnPackageOrder(Package package)
    {
        print("tell player that package order has been created");
        customer.ReturnToIdleState();
    }

    public void CancelPackageOrder(Package package)
    {
        customer.ReturnToIdleState();
    }

    public void AcceptPackageOrder(Package package)
    {
        customer.WaitForOrder();
    }
}