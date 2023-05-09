using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    // hversu mörg stig einn gem gefur player
    public int gemValue = 1;
    // skoðar collisions sem gem lendir í
    private void OnTriggerEnter2D(Collider2D other)
    {
        // finnur hvað player er
        PlayerMovement controller = other.GetComponent<PlayerMovement>();
        // og hvort að collsionið er playerinn eða ekki
        if (controller != null )
        {
            // kallar á fall í PlayerController sem að bætir á score eftir gem value
            controller.setScore(gemValue);
            // og svo eyðir gem
            Destroy(gameObject);
        }
    }
}
