using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// scripta fyrir projectileinn
public class Projectile : MonoBehaviour
{
    // rigidbody fyrir projectile
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        // fundið rigidbody component
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    // fall til að "skjota" skotinu
    public void Launch(Vector2 direction, float force)
    {
        // bætir við forcei við projectileið í directionið sem playerinn er að horfa í með ákveðnu forcei
        rigidbody2d.AddForce(direction * force);
        
    }

    void Update()
    {
        // og svo hérna til að skoða hversu langt frá 0,0 projectileið er
        if (transform.position.magnitude > 1000.0f && transform.position.magnitude < -1000.0f)
        {
            // ef það er of langt í burtu er því eytt
            Destroy(gameObject);
        }
    }
    // skoðar collisions á projectileinu
    void OnCollisionEnter2D(Collision2D other)
    {
        // finnur enemycontroller 
        EnemyController e = other.collider.GetComponent<EnemyController>();
        // skoðar hvort það sé til og hvort að projectile hittir enemy
        if (e != null)
        {
            // og ef það gerir er "lagað" robotinn
            e.Fix();
        }
        // og svo projectileinnu eytt
        Destroy(gameObject);
    }
}