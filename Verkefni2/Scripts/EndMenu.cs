using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// klassi til að geta notað takkana á end screeninu
public class EndMenu : MonoBehaviour
{
    // fall til að geta hætt í leiknum
    public void QuitGame() {
        // slekkur á leiknum
        Application.Quit();
    }
    // fall til að geta spilað leikinn aftur
    public void PlayAgain() {
        // hérna loada ég level 1 aftur þannig að þú getur spilað aftur
        SceneManager.LoadScene("Level01");
        // og reseta coin teljarann aftur í 0
        ItemCollector.CoinCounter = 0;
    }
}
