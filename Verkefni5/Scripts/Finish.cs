using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// klassi til að geta notað takkana á end screeninu
public class Finish : MonoBehaviour
{
    public void End()
    {
        SceneManager.LoadScene("EndMenu");
    }
}