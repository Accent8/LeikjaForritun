using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// scripta til a� stj�rna start screeninu
public class RespawnScreen : MonoBehaviour
{
    public void Respawn()
    {
        // l�t forriti� bara hla�a n�sta scenei � build indexinu
        SceneManager.LoadScene("MainLevel");
    }
}