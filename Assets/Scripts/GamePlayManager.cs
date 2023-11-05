using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    CustomerAiController customer;

    public static GamePlayManager instance;
    private void Start()
    {
        instance = this;
    }
    private void Update()
    {

    }

    public void placeOrder()
    {

    }
}