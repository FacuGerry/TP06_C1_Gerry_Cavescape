using TMPro;
using UnityEngine;

public class UiOrbs : MonoBehaviour
{
    [SerializeField] private OrbController orbs;
    [SerializeField] private TextMeshProUGUI currentOrbsText;
    [SerializeField] private TextMeshProUGUI totalOrbsText;


    void Start()
    {
        totalOrbsText.text = orbs.necessaryOrbs.ToString("0");
    }

    void Update()
    {
        currentOrbsText.text = orbs.numOfOrbs.ToString("0");
    }
}
