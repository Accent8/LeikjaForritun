using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// scripta fyrir end screen
public class EndScreen : MonoBehaviour
{
    public void Quit()
    {
        // segir bara forritinu að slökkva á ser
        Application.Quit();
    }
    // og ef player vil byrja aftur og ýttir á takkan
    public void StartAgain()
    {
        // loadar það því aðal levelinu svo player getur spilað aftur
        SceneManager.LoadScene("MainLevel");
    }
}
