using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// klassi til a� geta nota� takkana � end screeninu
public class Finish : MonoBehaviour
{
    public void End()
    {
        SceneManager.LoadScene("EndMenu");
    }
}