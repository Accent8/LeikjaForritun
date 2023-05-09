using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// scripta til að stjóna tutorial skjá
public class TutorialScript : MonoBehaviour
{
    // fall þegar hann ýtir á takkan
    public void StartGame()
    {
        // svo bara látið player fara í mainlevel til að spila
        SceneManager.LoadScene("MainLevel");
    }
}