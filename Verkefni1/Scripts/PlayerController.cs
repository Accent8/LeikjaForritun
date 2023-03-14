using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Breyta fyrir hraða fyrir playerinn
    public float speed = 0;
    // Tvö texta object bæði count og wintext
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;

    private float movementX;
    private float movementY;
    

    // Start is called before the first frame update
    void Start()
    {
        // breyta fyrir Rigidbody
        rb = GetComponent<Rigidbody>();
        // teljari
        count = 0;
        // fall fyrir count textann
        SetCountText();
        // og hér slekk ég á 
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        // Vector 2 fyrir færingu á playernum
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText() {
        // Fall til að updatea count textann
        countText.text = "Count: " + count.ToString();
        if(count >= 12) {
            // og ef count er meiri eða jafnt og 12 færðu you win textann
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        // hér er hreyfinginn á playernum og það bætir force á kúluna til að ýta henni áfram eftir hvað notandinn er að ýta á
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        // hér er forceið bætt við
        rb.AddForce(movement * speed);
    }
    // fall til að gá hvort að þú hittir eitthvað
    private void OnTriggerEnter(Collider other) 
    {
        // ef þú hittir object með taginu Pickup
        if(other.gameObject.CompareTag("Pickup")) {
            // slekkur unity á objectinu(þannig að þú sérð það ekki)
            other.gameObject.SetActive(false);
            // bætir 1 í count og updatear count textan
            count = count +1;
            SetCountText();
        }
    }

}