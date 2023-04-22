using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// scripta til að stjórna start screeninu
public class RespawnScreen : MonoBehaviour
{
    public void Respawn()
    {
        // læt forritið bara hlaða næsta scenei í build indexinu
        SceneManager.LoadScene("MainLevel");
    }
}