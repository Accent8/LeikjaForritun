using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// scripta til að festa playerinn við platform
// svo hann þarf ekki að labba sjálfur til að halda sér við platformið
public class StickyPlatform : MonoBehaviour
{
    // fall til að skoða collisions á platformunum
    private void OnCollisionEnter(Collision collision)
    {
        // ef gameobjectið sem collidear með platforminum heitir player
        if (collision.gameObject.name == "Player") {
            // er fært player niður og gert hann sem "child" af platforminum
            collision.gameObject.transform.SetParent(transform);
        }
    }
    // fall til að skoða hvort að player hafi farið af platforminum
    private void OnCollisionExit(Collision collision)
    {
        // ef player fer af platforminum er breytt honum sov hann verði ekki lengur
        // "child" af platforminum
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
