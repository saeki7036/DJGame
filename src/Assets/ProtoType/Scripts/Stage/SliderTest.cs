using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    Clickforposition clickforposition;
    [SerializeField]
    Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clickforposition.SetRotationAdjust((int)slider.value);
        text.text = ((int)slider.value).ToString();
    }
}
