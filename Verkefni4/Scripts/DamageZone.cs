using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// scripta fyrir damage zones i leiknum
public class DamageZone : MonoBehaviour
{   
    // skoðar hvort að ruby er inni damage zone
    void OnTriggerStay2D(Collider2D other)
    {
        // finnur controller hjá ruby
        RubyControler controller = other.GetComponent<RubyControler>();
        // ef það er controller
        if(controller != null)
        {
            // mínusar það 1 health frá
            controller.ChangeHealth(-1);
        }
    }
}
