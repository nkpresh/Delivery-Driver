using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField]
    GameObject notificationPrefab;

    [SerializeField]
    Transform notificationContainer;
    List<NotificationUI> notificationUIs;

    [SerializeField]
    TextMeshProUGUI packageAmountText;

    [SerializeField]
    Slider carHealthProgress;
    [SerializeField]
    TextMeshProUGUI timerUi;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        notificationUIs = new List<NotificationUI>();
    }

    public void CreateNotification(string customerName, string orderLocation, int packageIndex)
    {
        NotificationUI notificationPanel = notificationUIs.Find(x => x.gameObject.activeSelf == false);
        if (notificationPanel == null)
        {
            notificationPanel = Instantiate(notificationPrefab, notificationContainer).GetComponent<NotificationUI>();
            notificationUIs.Add(notificationPanel);
        }
        notificationPanel.UpdateNotificationPanel(customerName + " made an order at the " + orderLocation, packageIndex);
    }

    public void AssignPackageValue(float amount)
    {
        packageAmountText.text = amount.ToString();
    }

    internal void UpdateCarHealthProgress(float amount)
    {
        carHealthProgress.value = amount;
    }

    internal void UpdateTimerUi(float timeInMinutes, float timeInSeconds)
    {
        timerUi.text = timeInMinutes + " : " + timeInSeconds;
    }

    public void PauseGame()
    {
        GamePlayManager.instance.PauseGame();
    }
}
