using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// scripta til a� stj�rna start screeninu
public class EndScreen : MonoBehaviour
{
    public void Quit()
    {
        // l�t forriti� bara hla�a n�sta scenei � build indexinu
        Application.Quit();
    }
    public void StartAgain()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
