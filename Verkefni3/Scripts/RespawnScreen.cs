using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// öll scriptann á bakvið respawn
public class RespawnScreen : MonoBehaviour
{
    public void Respawn()
    {
        // sem segir bara unity að loada main levelinu
        SceneManager.LoadScene("MainLevel");
    }
}