using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// scripta til að stjórna start screeninu
public class EndScreen : MonoBehaviour
{
    public void Quit()
    {
        // læt forritið bara hlaða næsta scenei í build indexinu
        Application.Quit();
    }
    public void StartAgain()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
