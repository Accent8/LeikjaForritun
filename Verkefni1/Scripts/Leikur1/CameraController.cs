using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // setja inn nýja breytu sem skilgreinir hvaða game object er player
    public GameObject player;
    
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {   // Lítill koði sem passar að myndavélinn byrji á koðanum
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // og hér er passað að myndavélinn heldur sér á playernum í hverjum framei
        transform.position = player.transform.position + offset;
    }
}
