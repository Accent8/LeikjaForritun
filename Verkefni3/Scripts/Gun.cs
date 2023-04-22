using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Gun : MonoBehaviour
{
    public float range = 500f;
    public float firerate = 20f;
    public Camera fpsCam;
    CharacterStats myStats;
    public AudioSource m_shootingSound;

    private float nextTimeToFire = 0f;
    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        m_shootingSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/firerate;
            Shoot();
        }
    }

    void Shoot()
    {
        m_shootingSound.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyStats target = hit.transform.GetComponent<EnemyStats>();

            if (target != null)
            {
                target.TakeDamage(myStats.damage.getValue());
            }
        }
    }
}
