using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class CustomerRequestPackage : CustomerBaseState
{
    float waitTimer = 0;
    public void EnterState(CustomerAiController controller)
    {
        waitTimer = 0;
        Package package = controller.CreatePakage();
        GamePlayManager.instance.OnPackageOrder(package);
    }

    public void UpdateState(CustomerAiController controller)
    {
        if (controller.orderReceived)
        {
            ExitState(controller);
        }

    }

    public void ExitState(CustomerAiController controller)
    {
        controller.WaitForOrder();
    }
}
