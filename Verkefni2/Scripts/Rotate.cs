using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// skripta til að láta peningana snúast
public class Rotate : MonoBehaviour
{
    // 3 breytur fyrir mismunandi hraða á alla ása
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float speedZ;

    void Update()
    {
        // og svo láta þá bara rotatea og sinnuma það með 360 svo þeir fari heilan hring og svo sinnuma með "Time.deltaTime"
        // svo að það gerist jafn hratt fyrir alla og fer ekki eftir hversu mörg frames þú ert með
        transform.Rotate(360 * speedX * Time.deltaTime, 360 * speedY * Time.deltaTime, 360 * speedZ * Time.deltaTime);
    }
}
