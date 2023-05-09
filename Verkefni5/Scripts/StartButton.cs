using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// scripta til að stjórna start screeninu
public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        // læt forritið bara hlaða næsta scenei í build indexinu
        SceneManager.LoadScene("Tutorial");
    }
}