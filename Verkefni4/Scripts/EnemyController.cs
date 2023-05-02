using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // breytta fyrir speed á enemy
    public float speed;
    // hvort að hann labbar lárétt eða ekki
    public bool vertical;
    // tíminn sem hann er að labba í ákveðna átt
    public float changeTime = 3.0f;
    // Rigidbody fyir enemy
    Rigidbody2D rigidbody2D;
    // timer til að stjórna hvenær enemy skiptir um átt
    float timer;
    // hvaða átt
    int direction = 1;
    // og hvort að robot er broken eða ekki
    bool broken = true;
    // finnur particle system fyrir reikinn úr robot
    public ParticleSystem smokeEffect;
    // og svo animator fyrir animations
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {   // finnur rigidbody componentið
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        // og animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ef hann er ekki broken
        if (!broken)
        {
            // fer það úr þessu
            return;
        }
        // mínusar time með deltatime
        timer -= Time.deltaTime;
        // ef timer er 0 
        if (timer < 0)
        {   // breytir hann um direction
            direction = -direction;
            // og timer restar í byrjunar value
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        // skoðar hvort hann sé broken
        if (!broken)
        {
            return;
        }
        // finnur posistion á enemy
        Vector2 position = rigidbody2D.position;
        // ef hann labbar lárétt
        if (vertical)
        {
            // er hann látinn labba þannig
            position.y = position.y + Time.deltaTime * speed * direction;
            // svo bara breytur fyrir animator svo hann notar rétta animation
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        // annars
        else
        {
            // láttinn labba lóðrétt
            position.x = position.x + Time.deltaTime * speed * direction;
            // og svo rétta animation spilað
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        // svo látið rigidbodyinn labba í positionið
        rigidbody2D.MovePosition(position);
    }
    // skoðað collisions á enemi
    void OnCollisionEnter2D(Collision2D other)
    {
        // fundið hvað player er
        RubyControler player = other.gameObject.GetComponent<RubyControler>();
        // ef player er til og enemy fer í hann
        if (player != null)
        {
            // er minkað healthið um einn
            player.ChangeHealth(-1);
        }
    }

    // svo ef Ruby skítur hann með gear fer þetta fall í gang
    public void Fix()
    {
        // broken verður false
        broken = false;
        // "slekkur" á rigidbody svo að enemy labbi ekki um
        rigidbody2D.simulated = false;
        // og svo stoppað smoke effectinu
        smokeEffect.Stop();
        
    }
}