using Enums;
using UnityEngine;

public class Package : MonoBehaviour
{
    public PackageType packageType;
    public OrderLocations packageLocation;
    public string customerName;
    public PackageState packageState;

    public void SetupPackage(PackageType packageType, string customerName, OrderLocations orderLocation)
    {
        this.packageType = packageType;
        this.customerName = customerName;
        packageState = PackageState.Instation;
        packageLocation = orderLocation;
    }

    public void PickupPackage(Transform driver)
    {
        gameObject.SetActive(false);
        packageState = PackageState.Pickedup;
        transform.parent = driver;
    }
    public void OnPackageDelivered(Transform customer)
    {
        // gameObject.SetActive(false);
        packageState = PackageState.Delivered;
        transform.parent = customer;
    }
}