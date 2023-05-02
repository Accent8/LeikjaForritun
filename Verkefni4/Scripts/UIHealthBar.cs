using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// scripta fyrir health barinn
public class UIHealthBar : MonoBehaviour
{
    // public static svo að aðrar scriptur geta sótt þetta
    public static UIHealthBar instance { get; private set; }
    // image mask
    public Image mask;
    // og svo original stærðinn á health barinnu
    float originalSize;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // setur original stærð í stærðinna sem þetta byrjar í
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        // svo er þetta til að breyta stærð eftir healthi
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
