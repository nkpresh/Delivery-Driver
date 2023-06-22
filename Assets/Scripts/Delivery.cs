using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField]
    Color hasPackageColor = Color.green;
    [SerializeField]
    Color deliveredPackageColor = Color.white;
    [SerializeField]
    float destroyTime;
    bool packagePickedup = false;

    SpriteRenderer spriteRenderer;
    void OnTriggerEnter2D(Collider2D other)
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (other.tag == "Package" && !packagePickedup)
        {
            Debug.Log("Package picke up");
            packagePickedup = true;
            Destroy(other.gameObject, 1);
            spriteRenderer.color = hasPackageColor;
        }
        else if (other.tag == "Customer" && packagePickedup)
        {
            Debug.Log("Package Delivered");
            packagePickedup = false;
            spriteRenderer.color = deliveredPackageColor;

        }

    }
}