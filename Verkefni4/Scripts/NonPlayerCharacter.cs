using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
// scripta fyrir NPC
public class NonPlayerCharacter : MonoBehaviour
{
    // hversu lengi textinn á að vera
    public float displayTime = 4.0f;
    // texta kassia breyta
    public GameObject dialogBox;
    // og önnur breyta fyrir texta boxa lengd
    float timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        // felur dialogbox
        dialogBox.SetActive(false);
        // setur timer í -1
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // ef timer er stærra en eða jafnt og 0
        if(timerDisplay >= 0)
        {
            // er timer settur við delta time
            timerDisplay = Time.deltaTime;
            // og ef það er minna en 0
            if(timerDisplay < 0 )
            {
                // er slökkt á dialogboxinnu
                dialogBox.SetActive(false);
            }
        }
    }
    // fall til að kvekja á dialog boxi
    public void DisplayDialog()
    {
        // timer settur í displaytime
        timerDisplay = displayTime;
        // og svo kvekt á dialogboxi
        dialogBox.SetActive(true);
    }
}
