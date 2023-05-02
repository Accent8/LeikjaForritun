using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// skripta fyrir healthcollectible
public class HealthCollectible : MonoBehaviour
{
    // AudioClip fyrir collection af healthi
    public AudioClip collectedClip;
    // svo skoðar hvort að health object collidei við eitthvað
    void OnTriggerEnter2D(Collider2D other)
    {   
        // finnur hvað player er
        RubyControler controller = other.GetComponent<RubyControler>();
        // ef player er til og er að collidea við health object
        if (controller != null )
        {
            // og ef health er minna en max health
            if(controller.health < controller.maxHealth )
            {
                // bættir það við einu healthi við player
                controller.ChangeHealth(1);
                // eyðir health objectinu sem playerinn vað að picka upp
                Destroy(gameObject);
                // og spilar svo hljóðið
                controller.PlaySound(collectedClip);
            }
        }
    }
}
