using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Max health breyta til að geyma hvað max líf af character má vera
    public int maxHealth = 100;

    // current health til að geyma hversu mikið líf player er með, set public get svo maður getur sótt þetta hvar sem er og private set svo bara þessi skrá getur breytt tölunni
    public static int currenthealth {  get; private set; }
    // tvær breytur fyrir damage (bara hversu öflugt er högg/byssukúla frá character)
    public Stat damage;

    void Awake()
    {
        // hér verður current health jafn mikið og max health
        currenthealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
       // hér tek ég damage frá lífi characters 
        currenthealth -= damage;
        // og ef líf verður 0
        if(currenthealth <= 0) 
        {
            // er kallað á fall til að drepa character
            Die();
        }
    }
    // hér að það fall og það er tómt en það er líka virtual svo ég get breytt hvernig characterar deyja hvort sem það er player eða enemy
    public virtual void Die()
    {

    }
}
