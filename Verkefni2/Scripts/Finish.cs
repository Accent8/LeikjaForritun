using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// þetta forrit er til að fara á næsta level ef þú ferð yfir "finish line"
public class Finish : MonoBehaviour
{
    // hér skoða ég hvort að finish game objectið rekst á eitthvað object
    private void OnTriggerEnter(Collider other)
    {
        // ef objectið sem finish lineið collidar við heitir "Player"
        if (other.gameObject.name == "Player") {
            // fer það í build indexið og fer í næsta scene eða level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
