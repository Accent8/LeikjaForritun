using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Þetta forrit er notað til að safna peningum
public class ItemCollector : MonoBehaviour
{
    // hérna geri ég static int til að telja peninginn
    // og geri það public til að aðrar scriptur geta sótt í númerið og breytt því í
    // 0 eins og til dæmis þegar playerinn deyr eða bara svo að teljarinn fer ekki 0 þegar playerinn
    // fer í næsta level
    public static int CoinCounter = 0;
    // TMPro texti til að geta farið upp við hvert coin sem playerinn safnar
    [SerializeField] TextMeshProUGUI coinsText;

    private void Start()
    {
        // í byrjun leiks eða byrjun næsta level fer counterinn í sama gildi og "CoinCounter" er
        coinsText.text = "Coins : " + CoinCounter;
    }
    // hér skoðar forritið hvort að playerinn collidar við eitthvað
    private void OnTriggerEnter(Collider other)
    {
        // ef hann collidar við game object með tagginu coin
        if (other.gameObject.CompareTag("Coin")) {
            // eyðir það coininu
            Destroy(other.gameObject);
            // bættir svo í coin counterinn
            CoinCounter++;
            // og svo uppfærir það coinTextann
            coinsText.text = "Coins : " + CoinCounter;
        }
    }
}
