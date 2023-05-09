using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// scripta til að stjórna start screen
public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        // segir leiknum að fara á tutorial senuna
        SceneManager.LoadScene("Tutorial");
    }
}