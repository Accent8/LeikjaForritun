using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // breyta fyrir controllerinn
    public CharacterController2D controller;
    // og fyrir animatorinn fyrir player
    public Animator animator;
    // og svo fyrir score textann
    public TextMeshProUGUI scoreText;
    // breyta fyrir runspeed
    public float runSpeed = 40f;
    // breyta fyrir score fyrir player
    public static int score = 1;
    // og svo breyta fyrir input hjá player á horizontal ásinum
    float horizontalMove = 0f;
    // tvær bool fyrir jump og crouch
    bool jump = false;
    bool crouch = false;


    void Start()
    {
        // setur score textann í það sem er í gæsalöppum
        scoreText.SetText("Score : 0");
    }
    // Update is called once per frame
    void Update()
    {
        // fær input frá notanda
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // lætur svo það inn í animator svo hann getur notað það fyrir animations
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        // sér ef player er að halda niður space
        if(Input.GetButtonDown("Jump"))
        {   
            // setur jump á true og spilar animationið
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        // og sama með crouch
        if(Input.GetButtonDown("Crouch"))
        {   
            // setur crouch á true
            crouch = true;
        }
        // og ef player sleppir crouch
        else if(Input.GetButtonUp("Crouch"))
        {   
            // er crouch sett á false
            crouch = false;
        }
        // skoðar ef score players er minni en 0
        if(score <= 0)
        {
            // ef score er minna en 0 er kallað á fall til að drepa player
            die();
        }
    // fall til að setja score texta, tekur inn score value
    }
    public void setScore(int scoreValue)
    {
        // bætir score value á heildar score player
        score = score + scoreValue;
        // og uppfærir textann
        scoreText.SetText("Score : " + score);
    }
    // fall til að skoða lendingar hjá player
    public void OnLanding()
    {
        // þegar hann lendir er basicly sagt animator að slökkva á jump animation
        animator.SetBool("IsJumping", false);
    }
    // fall til að skoða crouch hjá player
    public void onCrouching(bool isCrouching)
    {   
        // og ef hann er að croucha eða ekki er það sent inn í animator til að slökkva eða kvekja á crouch animation
        animator.SetBool("IsCrouching", isCrouching);
    }
    // fixed update fyrir hreyfingar á player
    void FixedUpdate()
    {
        // hérna er skoðað hvort að player er að hreyfa sig eða croucha eða að hoppa
        controller.Move(horizontalMove * Time.fixedDeltaTime ,crouch,jump);
        // og lætur svo jump í false svo player getur ekki hoppað endalaust
        jump = false;
    }
    // fall til að drepa player
    void die()
    {
        // sem sendir player bara í enda senu svo hann getur annað hvort hætt eða spilað aftur
        SceneManager.LoadScene("EndScreen");
    }
    // skoðað collisions hjá player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ef hann collidar við eitthvað með tagginu "finish"
        if(collision.gameObject.CompareTag("finish"))
        {
            // er hann sendur í enda senu til að hætta að spila eða til að spila aftur
            SceneManager.LoadScene("EndScreen");
        }
    }
}
