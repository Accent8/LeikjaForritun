using UnityEngine;
// lætur þannig að byssan þarf characterStats er bara með þetta svo að byssan er með damage modifyer
[RequireComponent(typeof(CharacterStats))]
// fall til að stjórna byssun
public class Gun : MonoBehaviour
{
    // range á byssum
    public float range = 500f;
    // hversu hratt byssan getur skotið
    public float firerate = 20f;
    // myndavél fyrir byssuna (er bara first person cameran)
    public Camera fpsCam;
    // finnur statinn á byssunni
    CharacterStats myStats;
    // hljóð fyrir byssuna
    public AudioSource m_shootingSound;
    // til að reikna hvenær byssa getur skotið aftur
    private float nextTimeToFire = 0f;
    // start fall
    private void Start()
    {
        // nær í statinn á byssuni
        myStats = GetComponent<CharacterStats>();
        // og AudioSourceið fyrir hljóið á byssuni
        m_shootingSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Hér er skoðað hvort að player er að halda niður left mouse button og hvort að tíminn til að skjóta er 0 svo að player getur skotið
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            // resetar tíman til að skjóta aftur í það sem það á að vera
            nextTimeToFire = Time.time + 1f/firerate;
            // og kallar að fallið til að skjóta
            Shoot();
        }
    }
    // fall til að skjóta
    void Shoot()
    {
        // spilar hlóðið fyrir byssuna
        m_shootingSound.Play();
        // breyta fyrir raycast
        RaycastHit hit;
        // if setnint til að skoða hvað raycastið hitti
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // finnur targetið og sér hvort það er með Enemystats
            EnemyStats target = hit.transform.GetComponent<EnemyStats>();
            // ef targetið er með Enemystats
            if (target != null)
            {
                // ræðst það á statinn hjá targetinu
                target.TakeDamage(myStats.damage.getValue());
            }
        }
    }
}
