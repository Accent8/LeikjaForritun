using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    // breytta fyrir speed á enemy
    public float speed;
    // hvort að hann labbar lárétt eða ekki
    public bool vertical;
    // tími til að sjá hversu lengi hann labbar í ákveðna átt
    public float changeTime = 3.0f;
    // Rigidbody fyir enemy
    Rigidbody2D rigidbody2D;
    // timer til að stjórna átt enemies
    float timer;
    // hvaða átt
    int direction = 1;
    // og svo animator fyrir animations
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {   // finnur rigidbody componentið
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        // ef timer er 0 
        if (timer < 0)
        {   // breytir hann um direction
            direction = -direction;
            transform.Rotate(0, 180, 0);
            // og timer restar á byrjunar value
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        // finnur posistion á enemy
        Vector2 position = rigidbody2D.position;
        // ef hann labbar lárétt
        if (vertical)
        {
            // er hann látinn labba þannig
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        // annars
        else
        {
            // láttinn labba lóðrétt
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        // svo látið rigidbody labba á postion
        rigidbody2D.MovePosition(position);
    }
    // skoðar collisions á enemy
    void OnCollisionEnter2D(Collision2D other)
    {
        // fundið hvað playerinn er
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
        // ef player er til og enemy fer í hann
        if (player != null)
        {
            // er tekið 1 frá player scorei
            player.setScore(-1);
        }
        // og ef player er fyrir ofan hann í y ás
        if(player.transform.position.y > transform.position.y)
        {   
            // er eytt enemy objectinu
            Destroy(gameObject);
            // og player fær stig
            player.setScore(1);
            // þetta er bara svona eins og mario kill þannig þú hoppar á hausinn á honum og drepur óvinn þannig
        }
    }
}