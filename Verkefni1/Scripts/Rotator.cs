using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // bara basic rotate kóði til að rotatea Pickup objectunum svo það verði nett hreyfing á þeim
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
    }
}
