using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAwaitingPackage : CustomerBaseState
{

    float waitTime;
    public void EnterState(CustomerAiController controller)
    {
        Debug.Log("waiting for package");
    }

    public void ExitState(CustomerAiController controller)
    {
        if (controller.packageReceived){
            controller.EnterIdleState();
        }else{
            
        }
    }

    public void UpdateState(CustomerAiController controller)
    {
        if (waitTime >= controller.waitTime)
        {
            waitTime = 0;
            ExitState(controller);
        }
        else
        {
            waitTime += Time.deltaTime;
        }
    }
}
