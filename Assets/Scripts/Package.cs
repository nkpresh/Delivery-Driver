using Enums;
using UnityEngine;

public class Package : MonoBehaviour
{
    public PackageType packageType;
    // Sprite packageImage;
    // bool completed;

    public string customerName;

    public void SetupPackage(PackageType packageType, string customerName)
    {
        this.packageType = packageType;
        this.customerName = customerName;
    }



}