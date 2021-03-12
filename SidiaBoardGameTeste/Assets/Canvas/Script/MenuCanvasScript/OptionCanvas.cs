using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionCanvas : MonoBehaviour
{
    [SerializeField] Slider sliderWidth;
    [SerializeField] Slider sliderHeight;
    [SerializeField] Text valueTextWidth;
    [SerializeField] Text valueTextHeight;


    private void Start()
    {
        ValueTextWidth();
        ValueTextHeight();
    }

    private void Update()
    {
        ValueTextWidth();
        ValueTextHeight();
    }
    public void ValueTextWidth()
    {
        int minValue = 11;
        int valueTotal = minValue + Mathf.FloorToInt(sliderWidth.value * 10);
        valueTextWidth.text = "" + valueTotal;
    }
    public void ValueTextHeight()
    {
        int minValue = 11;
        int valueTotal = minValue + Mathf.FloorToInt(sliderHeight.value*10);
        valueTextHeight.text = "" + valueTotal;
    }

    public int GetValueHeight()
    {
        int minValue = 11;
        int valueTotal = minValue + Mathf.FloorToInt(sliderHeight.value * 10);
        return valueTotal;
    }
    public int GetValueWidth()
    {
        int minValue = 11;
        int valueTotal = minValue + Mathf.FloorToInt(sliderWidth.value * 10);
        return valueTotal;
    }
}
