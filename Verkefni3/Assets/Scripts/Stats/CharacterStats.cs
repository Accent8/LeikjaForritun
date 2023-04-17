using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;

    // set get og private set svo að hver sem er getur lesið value af currenthealth en getur ekki breytt því
    public static int currenthealth {  get; private set; }

    public Stat damage;
    public Stat armor;

    void Awake()
    {
        currenthealth = maxHealth;
    }
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        Debug.Log(transform.name + "takes " + damage + " damage");

        if(currenthealth <= 0) 
        {
            Die();
        }
    }
    public virtual void Die()
    {

    }
}
