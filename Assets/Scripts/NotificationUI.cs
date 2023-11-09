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
    float waitTime = 5;
    void OnEnable()
    {
        transparancy = GetComponent<CanvasGroup>();
    }
    void Update()
    {

        if (waitTime <= 0)
        {
            transparancy.alpha -= Time.deltaTime;
            if (transparancy.alpha <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

    }
    public void UpdateNotificationPanel(string data)
    {
        transparancy.alpha = 1;
        descriptionText.text = data;
        waitTime = 5;
        gameObject.SetActive(true);
    }

    public void OnSelectOrder()
    {
        
    }
    public void OnCancelOrder()
    {

    }
}
