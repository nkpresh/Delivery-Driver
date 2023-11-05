using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRequestPackage : CustomerBaseState
{
    float waitTimer = 0;
    public void EnterState(CustomerAiController controller)
    {
        waitTimer = 0;
        
    }

    public void ExitState(CustomerAiController controller)
    {
        controller.WaitForOrder();
    }

    public void UpdateState(CustomerAiController controller)
    {
        if (controller.orderReceived)
        {

        }

    }
}
