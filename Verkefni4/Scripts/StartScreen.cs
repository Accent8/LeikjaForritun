using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// þessi er fyrir start screen
public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        // segir bara build index + 1 sem fer í næstu sceneu í build index sem er main levelið
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
