using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EquipmentManager;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
    }
    
    void onEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.addModifier(newItem.armorModifier);
            damage.addModifier(newItem.damageModifier);
        }

        if(oldItem != null)
        {
            armor.removeModifier(oldItem.armorModifier);
            damage.removeModifier(oldItem.damageModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}