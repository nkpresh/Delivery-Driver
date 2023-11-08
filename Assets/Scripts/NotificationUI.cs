using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI descriptionText;
    public bool isActive;
    CanvasGroup transparancy;
    float waitTime = 5;
    void Start()
    {
        transparancy = GetComponent<CanvasGroup>();
    }
    private void OnEnable()
    {
        isActive = true;
    }

    void Update()
    {

        if (waitTime <= 0)
        {
            transparancy.alpha -= Time.deltaTime;
            if (transparancy.alpha <= 0)
            {
                gameObject.SetActive(false);
                isActive = false;
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

    }
    public void UpdateNotificationPanel(string data)
    {
        descriptionText.text = data;
    }
}
