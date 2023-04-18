using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        PlayerManager.currentEnemies -= 1;
        PlayerManager.currentPoints += 5;
    }
}
