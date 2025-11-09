using System;
using UnityEngine;
using UnityEngine.UI;

public class UiToggleHUD : MonoBehaviour
{
    public static event Action<UiToggleHUD> onToggleClicked;

    [SerializeField] private GameObject hud;
    [SerializeField] private PlayerPrefsSo playerPrefs;
    private Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = playerPrefs.isHudOn;
        hud.SetActive(playerPrefs.isHudOn);
        toggle.onValueChanged.AddListener(ToggleHUD);
    }

    void OnDestroy()
    {
        toggle.onValueChanged.AddListener(ToggleHUD);
    }

    public void ToggleHUD(bool isHudOn)
    {
        playerPrefs.isHudOn = isHudOn;
        hud.SetActive(playerPrefs.isHudOn);
        onToggleClicked?.Invoke(this);
    }
}
