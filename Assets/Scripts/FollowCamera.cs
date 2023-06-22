using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject deafMcDrive;

    void LateUpdate()
    {
        transform.position = deafMcDrive.transform.position + new Vector3(0, 0, deafMcDrive.transform.position.z - 10);
    }
}
