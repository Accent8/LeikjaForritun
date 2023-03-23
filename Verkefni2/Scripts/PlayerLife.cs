using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// scripta til að skoða lífið á player
public class PlayerLife : MonoBehaviour
{
    // breyta til að sjá hvort að playerinn er dauður
    bool dead = false;

    private void Update()
    {   // þetta if fall skoðar hvort að playerinn er undir -3 á y ás
        if (transform.position.y < -3 && !dead) {
            // ef hann er undir því þá deyr hann
            Die();
        }
    }
    // Hér er deathtextinn geymdur til að geta kallað á hann seinna
    public GameObject deathText;

    private void Start()
    {
        // hér slekk ég á death textanum þannig að hann kemur bara þegar ég vill að hann kemur
        deathText.SetActive(false);
    }
    // fall til að skoða ef playerinn hittir eitthvað
    private void OnCollisionEnter(Collision collision)
    {
        // ef playerinn rekst í gameobject með taggið enemybody
        if (collision.gameObject.CompareTag("Enemy body")) {
            // deyr hann
            Die();
        }
    }
    // hérna er "Die" fallið sem er kallað ef playerinn á að "deyja"
    void Die() {
        // hér kvekji ég á deathtext fallinu
        deathText.SetActive(true);
        // læt coin counter í 0
        ItemCollector.CoinCounter = 0;
        // slekk á rendernum fyrir playerinn svo hann hverfur
        GetComponent<MeshRenderer>().enabled = false;
        // og læt hann verða kinematic
        GetComponent<Rigidbody>().isKinematic = true;
        // og slekk svo á playercontroller scriptuni svo að notandinn geti ekki
        // fært "dauðan" player
        GetComponent<PlayerController>().enabled = false;
        // læt dead breytuna verða true
        dead = true;
        // og svo kalla ég á fall til að reloada levelið eftir 2 sekúndur
        Invoke(nameof(ReloadLevel), 2f);

    }
    // hérna er fallið til að reloada levelið
    void ReloadLevel() {
        // sem lætur forritið bara hlaða sama leveli aftur
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
