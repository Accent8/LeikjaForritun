using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// hér geri ég requirecomponent svo til að þessi script virki þarf object að hafa CharacterStats
[RequireComponent(typeof(CharacterStats))]
// í staðinn fyrir að vera Monobehavior lét ég það vera Interactable sem er custom behavior sem ég forritaði
public class Enemy : Interactable
{
    // hef þetta til að fá playermanagerinn og myStats af enemy
    PlayerManager playerManager;
    CharacterStats myStats;

    void Start()
    {
        // bara sama og fyrir ofan nema hérna fæ ég það inn
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }
    // overrida fall í Interactable fallið
    public override void Interact()
    {
        // allt sem er í interact
        base.Interact();
        // og hér er charactercombat fæ sá component
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        // passa að player getur attackað
        if(playerCombat != null)
        {
            // og kalla svo á fall til að attacka
            playerCombat.Attack(myStats);
        }
    }

}
