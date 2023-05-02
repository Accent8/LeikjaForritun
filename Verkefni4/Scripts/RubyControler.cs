using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// aðal scriptann eða controllerinn fyir main characterinn
public class RubyControler : MonoBehaviour
{
    // hraði á player
    public float speed = 3.0f;
    // max health fyrir playerinn
    public int maxHealth = 5;
    // notað til að geyma hvað projectile er
    public GameObject projectilePrefab;
    // breyta fyrir health sem aðrar scriptur geta sótt og returnar bara current health
    public int health { get { return currentHealth; } }
    // notað til að geyma hvað current health er
    int currentHealth;
    // tíminn sem ekkert getur "hitt" ruby
    public float timeInvincible = 2.0f;
    // true or false hvort að ruby er ódrepanleg
    bool isInvincible;
    // og svo timer fyrir hversu lengi hún er ódrepanleg
    float invincibleTimer;
    // rigidbody á ruby
    Rigidbody2D rigidbody2d;
    // breytur fyrir horizontal og vertical axis
    float horizontal;
    float vertical;
    // og svo hljóðið sem kemur þegar ruby skítur
    public AudioClip shootsound;
    // animator fyrir ruby
    Animator animator;
    // og svo lookdirection
    Vector2 lookDirection = new Vector2(1, 0);
    // og audiosource
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {   
        // nær í rigidbody, animator og audiosource frá ruby
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        // og lætur currenthealth í maxhealth
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // nær í input frá notanda á bæði x og y ás
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // og geymir það í breytu sem heitir move
        Vector2 move = new Vector2(horizontal, vertical);
        // þetta er notað fyrir lookdirection
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            // og er það gert hér
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        // og svo eitthvað stuff fyrir animatorinn svo að hann veit hvaða animaton á að spila
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        // skoðar hvort að ruby er ódrepanleg
        if (isInvincible)
        {
            // og svo byrjar það að telja niður tímann
            invincibleTimer -= Time.deltaTime;
            // og ef tíminn er minni en 0
            if (invincibleTimer < 0)
                // er þá hægt að drepa ruby
                isInvincible = false;
        }
        // ef notandinn ýtir niður c
        if (Input.GetKeyDown(KeyCode.C))
        {
            // skítur ruby út projectile
            Launch();
        }
        // hef notandinn ýtir niður X
        if (Input.GetKeyDown(KeyCode.X))
        {
            // er kastað úr ray og skoðar hvað hún hittir og ef hún hittir eitthvað með layerinn NPC
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            // og það er eitthvað object
            if(hit.collider != null)
            {
                // er leitað af NonPlayerCharacter scriptinnu á objectinu
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                // ef object er með það
                if(character != null)
                {
                    // er þá displayað dialog boxinu
                    character.DisplayDialog();
                }
            }
        }
    }

    void FixedUpdate()
    {
        // skoðað position
        Vector2 position = rigidbody2d.position;
        // og svo sett í breytur með hraða og hvaða ás og tíma
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        // og svo látið ruby færa sig þangað
        rigidbody2d.MovePosition(position);
    }
    // fall til að breyta healthi á ruby
    public void ChangeHealth(int amount)
    {
        // ef það er minna en 0
        if (amount < 0)
        {
            // er skoaðað hvort hún er ódrepanleg 
            if (isInvincible) 
            {
            // ef hún er það er bara returnað úr fallinu
                return;
            // 
            }
            // annars er invinceble sett true eftir að er búið að taka health frá henni
            isInvincible = true;
            // og tíminn resetaður
            invincibleTimer = timeInvincible;
        }
        // það er mínusað current health við amount (sem er bara hversu mikill líf á að taka í burtu)
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        // og svo er updateað health barinn svo hann minki eða stækki
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    // fall til að skjóta
    void Launch()
    {
        // sótt gameojbectið sem er projectile
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        // svo er sótt projectile scriptuna
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        // henni er skotið í sá átt sem player er að stefna með forceinu 300
        projectile.Launch(lookDirection, 300);
        // animation set fyrir að skjóta
        animator.SetTrigger("Launch");
        // og soundið sett í gang til að skjóta
        PlaySound(shootsound);
    }
    // fall til að spila hljóð
    public void PlaySound(AudioClip clip)
    {
        // spilar bara hljóð
        audioSource.PlayOneShot(clip);
    }
}