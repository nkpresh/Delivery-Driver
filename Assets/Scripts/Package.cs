using Enums;
using UnityEngine;

public class Package : MonoBehaviour
{
    PackageType packageType;
    Sprite packageImage;


    public void SetupPackage(PackageType packageType)
    {
        this.packageType = packageType;
    }


}