using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiStrength : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private Image strengthBar;
    [SerializeField] private TextMeshProUGUI strengthText;

    private void OnEnable()
    {
        PickablesController.onPlayerAddDamage += OnPlayerAddDamage_AddDamage;
    }

    private void Start()
    {
        strengthText.text = data.damage.ToString("0");
        float lerp = data.damage / (float)data.maxDamage;
        strengthBar.fillAmount = lerp;
    }

    private void OnDisable()
    {
        PickablesController.onPlayerAddDamage -= OnPlayerAddDamage_AddDamage;
    }

    public void OnPlayerAddDamage_AddDamage(PickablesController pickablesController, int damage)
    {
        float lerp = damage / (float)data.maxDamage;
        strengthBar.fillAmount = lerp;
        strengthText.text = damage.ToString("0");
    }
}
