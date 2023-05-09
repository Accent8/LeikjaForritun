using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// klassi til að stjórna end menu
public class EndMenu : MonoBehaviour
{
    // fall til að slökkva á leiknum
    public void QuitGame()
    {
        // slekkur á leiknum
        Application.Quit();
    }
    // fall til að geta spilað leikinn aftur
    public void PlayAgain()
    {
        // hérna læt ég scenemanager bara loada main level aftur
        SceneManager.LoadScene("MainLevel");
        // og reseta score teljara í 1
        PlayerMovement.score = 1;
    }
}