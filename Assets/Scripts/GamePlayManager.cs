using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Enums;
using UnityEngine;
using UnityEngine.U2D.IK;

public class GamePlayManager : MonoBehaviour
{
    // [SerializeField]
    // List<CustomerAiController> customer;
    // [SerializeField]
    // Driver driver;

    [SerializeField]
    TimerHandler timerHandler;


    List<Package> packages;
    public static GamePlayManager instance;
    private void Start()
    {
        instance = this;
        packages = new List<Package>();
        StartGame();
    }
    public void CreatePackageOrder(Package package)
    {
        packages.Add(package);
        UiManager.instance.CreateNotification(package.customerName, package.packageLocation.ToString(), packages.Count - 1);
    }
    public void UpdatePackageData()
    {
        UiManager.instance.AssignPackageValue(GetSelectedPackages().Count);

    }

    public List<Package> GetSelectedPackages()
    {
        return packages.FindAll(x => x.packageState == PackageState.Pickedup);
    }
    public bool CheckCustomerPackages(string customerName)
    {
        return packages.Any(x => x.customerName == customerName && x.packageState != PackageState.Delivered);
    }
    public void OnGameOver(GameOverResult gameOverResult)
    {
        print(gameOverResult.ToString());
    }

    public void StartGame()
    {
        timerHandler.StartTime();
    }
    public void PauseGame()
    {
        timerHandler.PauseTime(true);
    }
}