using Enums;
using UnityEngine;

public class Package : MonoBehaviour
{
    public PackageType packageType;
    public string packageLocation;
    public string customerName;
    public PackageState packageState;

    public void SetupPackage(PackageType packageType, string customerName, string packageLocation)
    {
        this.packageType = packageType;
        this.customerName = customerName;
        packageState = PackageState.UnAssigned;
    }


}