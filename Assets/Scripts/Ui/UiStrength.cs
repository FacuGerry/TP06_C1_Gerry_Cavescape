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
    }

    private void OnDisable()
    {
        PickablesController.onPlayerAddDamage -= OnPlayerAddDamage_AddDamage;
    }

    public void OnPlayerAddDamage_AddDamage(PickablesController pickablesController, int damage)
    {
        strengthText.text = damage.ToString("0");
    }
}
