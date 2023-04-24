using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// skrá fyrir enemy statinn og hún tekur allt frá "CharacterStats" skránni svo ég er ekki með eina 
// langa skrá eða margar litlar sem stendur bara sama í aftur og aftur eins og líf og damage
public class EnemyStats : CharacterStats
{
    // í þessari skrá "override-a" ég bara "Die" fallið fyrir enemy
    public override void Die()
    {
        base.Die();
        // sem bara eyðir objectinu í þessu tilviki væri það enemyinn
        Destroy(gameObject);
        // minkar töluna af current enemies
        PlayerManager.currentEnemies -= 1;
        // og gefur player 5 stig
        PlayerManager.currentPoints += 5;
    }
}
