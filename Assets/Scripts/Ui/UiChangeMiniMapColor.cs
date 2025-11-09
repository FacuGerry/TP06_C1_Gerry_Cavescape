using UnityEngine;
using UnityEngine.UI;

public class UiChangeMiniMapBorderColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer miniMapBorder;
    [SerializeField] private PlayerPrefsSo playerPrefs;
    [SerializeField] private Slider sliderColorR;
    [SerializeField] private Slider sliderColorG;
    [SerializeField] private Slider sliderColorB;

    private void Awake()
    {
        AddListeners();
    }

    private void Start()
    {
        miniMapBorder.color = new Color(playerPrefs.miniMapColorR, playerPrefs.miniMapColorG, playerPrefs.miniMapColorB);

        sliderColorR.value = playerPrefs.miniMapColorR;
        sliderColorG.value = playerPrefs.miniMapColorG;
        sliderColorB.value = playerPrefs.miniMapColorB;
    }

    private void OnDestroy()
    {
        sliderColorR.onValueChanged.RemoveAllListeners();
        sliderColorG.onValueChanged.RemoveAllListeners();
        sliderColorB.onValueChanged.RemoveAllListeners();
    }

    public void AddListeners()
    {
        sliderColorR.onValueChanged.AddListener(OnSliderColorRChanged);
        sliderColorG.onValueChanged.AddListener(OnSliderColorGChanged);
        sliderColorB.onValueChanged.AddListener(OnSliderColorBChanged);
    }

    public void OnSliderColorRChanged(float red)
    {
        miniMapBorder.color = new Color(red / 255, miniMapBorder.color.g, miniMapBorder.color.b);
        playerPrefs.miniMapColorR = red;
    }

    public void OnSliderColorGChanged(float green)
    {
        miniMapBorder.color = new Color(miniMapBorder.color.r, green / 255, miniMapBorder.color.b);
        playerPrefs.miniMapColorG = green;
    }

    public void OnSliderColorBChanged(float blue)
    {
        miniMapBorder.color = new Color(miniMapBorder.color.r, miniMapBorder.color.g, blue / 255);
        playerPrefs.miniMapColorB = blue;
    }

}
