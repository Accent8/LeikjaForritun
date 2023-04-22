using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this; }
    #endregion


    public static int currentPoints { get; set; } = 0;
    public static int currentEnemies { get; set; } = 20;
    public GameObject player;
    public GameObject deathText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI enemiesText;
    int playerHealth;
    bool dead = false;
    public void Start()
    {

        playerHealth = CharacterStats.currenthealth;
        healthText.text = "Health: " + playerHealth;
        pointText.text = "Points: " + currentPoints;
        enemiesText.text = "Enemies Left: " + currentEnemies;

        deathText.SetActive(false);
    }

    private void Update()
    {
        healthText.text = "Health:" + playerHealth;
        pointText.text = "Points:" + currentPoints;
        enemiesText.text = "Enemies Left:" + currentEnemies;

        // þetta if fall skoðar hvort að playerinn er undir -3 á y ás
        if (player.transform.position.y < -3 && !dead)
        {
            // ef hann er undir því þá deyr hann
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
