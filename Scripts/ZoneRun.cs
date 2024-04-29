using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneRun : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            Debug.Log("You come in Zone");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            Debug.Log("You left in Zone");
        }
    }
}
