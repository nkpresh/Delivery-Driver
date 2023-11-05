using UnityEngine;

public interface CustomerBaseState
{
    public void EnterState(CustomerAiController controller);
    public void UpdateState(CustomerAiController controller);
    public void ExitState(CustomerAiController controller);
}