using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField]
    GameObject notificationPrefab;

    [SerializeField]
    Transform notificationContainer;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void CreateNotification(string customerName, string orderLocation)
    {
        GameObject notificationUI = Instantiate(notificationPrefab, notificationContainer);
        notificationUI.GetComponent<NotificationUI>().UpdateNotificationPanel(customerName + " made an order at the " + orderLocation);
    }
}
