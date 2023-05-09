using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public int gemValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement controller = other.GetComponent<PlayerMovement>();
        if (controller != null )
        {
            controller.setScore(gemValue);
            Destroy(gameObject);
        }
    }
}
