using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// scripta fyrir end screen
public class EndScreen : MonoBehaviour
{
    public void Quit()
    {
        // segir bara forritinu að slökkva á sér
        Application.Quit();
    }
    // og ef player vil byrja aftur og ýttir á takkan
    public void StartAgain()
    {
        // loadar það main level aftur
        SceneManager.LoadScene("MainLevel");
    }
}
