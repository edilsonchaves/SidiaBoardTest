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
    public Toggle toggleMusic;

    private void Start()
    {
        ValueTextWidth();
        ValueTextHeight();
    }

    private void Update()
    {
        ValueTextWidth();
        ValueTextHeight();
        ToggleMusic();
    }
    public void ToggleMusic()
    {
        ManagerGame.Instance.IsMusic = toggleMusic.isOn;
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
