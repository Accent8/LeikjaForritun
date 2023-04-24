using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EquipmentManager;
// hér er skript fyrir player statinn og eins og enemystats tekur það allt frá character stats
public class PlayerStats : CharacterStats
{
    // hérna overrida ég die fallið fyrir player
    public override void Die()
    {
        base.Die();
        // sem opnar bara fall í playermanager scriptinu og drepur player
        PlayerManager.instance.KillPlayer();
    }
    // svo skoða collisions hjá playernum
    private void OnCollisionEnter(Collision collision)
    {
        // ef hann snertir object með tagginu "Water"
        if (collision.gameObject.CompareTag("Water"))
        {
            // deyr hann
            Die();
        }
        // og ef hann fer í object með tagginu "Exit"
        if(collision.gameObject.CompareTag("Exit"))
        {
            // þá er leikurinn búinn og playerinn klárar leikinn
            SceneManager.LoadScene("EndMenu");
        }
    }

}
