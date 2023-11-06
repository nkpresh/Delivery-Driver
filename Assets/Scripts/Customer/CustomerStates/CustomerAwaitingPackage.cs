using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAwaitingPackage : CustomerBaseState
{

    float maxTime;
    float waitTime;
    public void EnterState(CustomerAiController controller)
    {
        Debug.Log("waiting for package");
    }

    public void ExitState(CustomerAiController controller)
    {
        Debug.Log("Exit state");
    }

    public void UpdateState(CustomerAiController controller)
    {
        if (waitTime >= maxTime)
        {
            ExitState(controller);
        }
    }
}
