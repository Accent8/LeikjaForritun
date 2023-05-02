using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// hérna segi ég bara til þess að fara í combat þurfa bæði object að hafa skriptið "CharacterCombat"
[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    // svo bara attack speed hversu hratt getur objectið attackað
    public float attackSpeed = 1f;
    // og svo cooldown
    private float attackCooldown = 0f;
    // nær í statin sem objectið hefur frá character stats
    CharacterStats myStats;

    void Start()
    {
        // nær í statin fyrir objectið hér
        myStats = GetComponent<CharacterStats>();  
    }

    void Update()
    {
        // svo er hérna er reiknað attack cooldownið þannig því minni því hraðar getur þú attackað
        // mínusar bara við tíma
        attackCooldown -= Time.deltaTime;
    }
    // fall til að attacka
    public void Attack(CharacterStats targetStats)
    {   // ef attackcooldown er 0 þá getur object attackað
        if (attackCooldown <= 0f) 
        {   // Hérna er attack skipun hún tekur bara damage sem objectið sem er að attack hefur í myStats og finnur targetið sitt og "ræðst" á healthið hjá targetinu
            targetStats.TakeDamage(myStats.damage.getValue());
            // og svo er attack cooldown set aftur í það sem það á að vera
            attackCooldown = 1f / attackSpeed;
        }
        
    }
}
