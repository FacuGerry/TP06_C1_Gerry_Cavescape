using UnityEngine;
using UnityEngine.UI;

public class UiChangeMiniMapBorderColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer miniMapBorder;
    [SerializeField] private Slider sliderColorR;
    [SerializeField] private Slider sliderColorG;
    [SerializeField] private Slider sliderColorB;

    void Awake()
    {
        ChangeColor();
    }

    void OnDestroy()
    {
        sliderColorR.onValueChanged.RemoveAllListeners();
        sliderColorG.onValueChanged.RemoveAllListeners();
        sliderColorB.onValueChanged.RemoveAllListeners();
    }

    public void ChangeColor()
    {
        sliderColorR.onValueChanged.AddListener(OnSliderColorRChanged);
        sliderColorG.onValueChanged.AddListener(OnSliderColorGChanged);
        sliderColorB.onValueChanged.AddListener(OnSliderColorBChanged);
    }

    public void OnSliderColorRChanged(float red)
    {
        miniMapBorder.color = new Color(red, miniMapBorder.color.g, miniMapBorder.color.b);
    }

    public void OnSliderColorGChanged(float green)
    {
        miniMapBorder.color = new Color(miniMapBorder.color.r, green, miniMapBorder.color.b);
    }

    public void OnSliderColorBChanged(float blue)
    {
        miniMapBorder.color = new Color(miniMapBorder.color.r, miniMapBorder.color.g, blue);
    }

}
