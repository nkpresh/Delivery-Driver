using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI descriptionText;
    CanvasGroup transparancy;
    bool canClosePanel;

    int index;
    float waitTime = 5;
    void OnEnable()
    {
        transparancy = GetComponent<CanvasGroup>();
    }
    void Update()
    {

        if (waitTime <= 0)
        {
            canClosePanel = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

        if (canClosePanel)
        {
            transparancy.alpha -= Time.deltaTime;
            if (transparancy.alpha <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void UpdateNotificationPanel(string data, int index)
    {
        canClosePanel = false;
        transparancy.alpha = 1;
        descriptionText.text = data;
        waitTime = 5;
        gameObject.SetActive(true);
        this.index = index;
    }
    public void OnCancelOrder()
    {
        canClosePanel = true;
    }
}
