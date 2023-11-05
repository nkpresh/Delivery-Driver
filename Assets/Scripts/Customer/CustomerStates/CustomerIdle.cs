using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class CustomerIdle : CustomerBaseState
{
    public void EnterState(CustomerAiController controller)
    {
        controller.customerEmotion = CustomerEmotion.Nice;
        controller.packageReceived = false;
    }

    public void ExitState(CustomerAiController controller)
    {

    }

    public void UpdateState(CustomerAiController controller)
    {

    }
}
