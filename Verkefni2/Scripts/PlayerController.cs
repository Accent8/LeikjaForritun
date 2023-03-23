using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // byrja að gera rigidbody breytu sem heitir rb
    Rigidbody rb;
    // float breytur fyrir hraðan og jump afl fyrir player
    public float speed;
    public float jump;
    // er svo með 2 breytur fyrir groundCheck til að skoða hvort player er á ground
    // og svo LayerMask til að stjórna hvað er ground
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        // Fæ rigidbodyinn á player game objectinu
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // hér fæ ég inn 2 float breytur fyrir Horizontal og Vertical input hjá playernum
        // (þetta virkar á bæði örvarnar og wasd)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // hérna læt ég velocity á playerinn eftir inputunum frá breytunum fyrir ofan
        // og margfalda þér svo með hraða breytunni þar sem inputinn eru bara á bilunum 1 til -1
        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, verticalInput * speed);
        // hér skoða ég eftir inputum frá player og athuga hvort hann er að ýta á space og svo hvort
        // hann er á jörðinni svo hann hoppi ekki í miðju lofti
        if (Input.GetButtonDown("Jump")  && IsGrounded())
        {
            // og kalla svo á fall svo hann geti hopað
            Jump();
        }
        // svo þessi 2 if eru til að snúa playernum
        if (Input.GetKey("f")){
            transform.Rotate(new Vector3(0, 2, 0));
        }
        if (Input.GetKey("r")){
            transform.Rotate(new Vector3(0, -2, 0));
        }
    }
    // þetta nota ég svo að playerinn geti hoppað á "hausana" á enemyunum
    private void OnCollisionEnter(Collision collision)
    {   // ef hann hittir object með taggið "Head"
        if (collision.gameObject.CompareTag("Head")) {
            // eyðir það objectinu sem head er child af
            Destroy(collision.transform.parent.gameObject);
            // og svo fyrir smá svona auka læt ég playerinn hoppa aftur
            Jump();
        }
    }
    // jiump fallið
    void Jump() {
        // rigidbody velocity svo að playerinn hoppi en heldur líka hraðanum sínum á
        // x og z ás
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
    }
    // fall til að skoða hvort að playerinn sé grounded
    bool IsGrounded()
    {
        // hér skoðar leikurinn hvort að playerinn sé að snerta eitthva gameobject með
        // layer maskið ground og ef hann er að því skilar true ef ekki false og þá getur playerinn
        // ekki hoppað
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}