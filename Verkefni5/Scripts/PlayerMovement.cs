using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public TextMeshProUGUI scoreText;

    public float runSpeed = 40f;
    public static int score = 1;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;


    void Start()
    {
        scoreText.SetText("Score : 0");
    }
    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if(score <= 0)
        {
            die();
        }

    }
    public void setScore(int scoreValue)
    {
        score = score + scoreValue;
        scoreText.SetText("Score : " + score);
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime ,crouch,jump);
        jump = false;
        
    }
    void die()
    {
        SceneManager.LoadScene("EndScreen");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if(collision.gameObject.CompareTag("finish"))
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
