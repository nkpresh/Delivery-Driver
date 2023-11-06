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
        controller.CreatePakage();
        Debug.Log("request state");
    }

    public void ExitState(CustomerAiController controller)
    {
        controller.WaitForOrder();
    }

    public void UpdateState(CustomerAiController controller)
    {
        if (controller.orderReceived)
        {
            ExitState(controller);
        }

    }
}
