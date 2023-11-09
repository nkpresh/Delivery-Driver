using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.U2D.IK;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    CustomerAiController customer;
    [SerializeField]
    Driver driver;


    List<Package> packages;
    public static GamePlayManager instance;
    private void Start()
    {
        instance = this;
        packages = new List<Package>();
    }
    public void CreatePackageOrder(Package package)
    {
        packages.Add(package);
        UiManager.instance.CreateNotification(package.customerName, package.packageLocation, packages.Count - 1);
    }

    public void AssignPackage(int index)
    {
        var currentPackage = packages[index];
        if (currentPackage.packageState == PackageState.UnAssigned)
        {
            currentPackage.packageState = PackageState.Selected;
            UiManager.instance.AssignPackageValue(packages.Count);
        }
    }
    public void CancelPackage(int index)
    {

    }

}