using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// kalla á Event og SceneManagement til að geta stjórnað sceneum
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
// og TMPro fyrir ui texta
using TMPro;

public class PlayerManager : MonoBehaviour
{
    // singleton til að geta set að þetta sé playermanagerinn og þá geta aðrar skriftur notað þetta og þá vita allir hver playermanagerinn er
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {   // hér læt ég að instance sem ég nota í öðrum skriftum sé bara þetta object
        instance = this; }
    #endregion

    // int fyrir fjölda stiga og óvinum sem eru með public get, set og er static svo að aðrar skriftur geta sótt þessi númer og breytt þeim
    public static int currentPoints { get; set; } = 0;
    public static int currentEnemies { get; set; } = 20;
    // gameObject til að sjá hvað er player
    public GameObject player;
    // og svo stiga texti og fjolda af óvinum texti
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI enemiesText;
    public void Start()
    {
        // set textann hérna á bara valueið af breytunum sem koma aftast
        pointText.text = "Points: " + currentPoints;
        enemiesText.text = "Enemies Left: " + currentEnemies;
    }

    private void Update()
    {
        // update-a textan hérna
        pointText.text = "Points:" + currentPoints;
        enemiesText.text = "Enemies Left:" + currentEnemies;

        // skoða ef player er undir -3 á y ás
        if (player.transform.position.y < -3)
        {
            // og ef hann er neðar en það kalla ég á fall til að drepa player
            KillPlayer();
        }
    }
    // hér er drepa player fall
    public void KillPlayer()
    {   // sem segir unity bara að fara í næsta scene sem er bara respawn skjárinn
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
