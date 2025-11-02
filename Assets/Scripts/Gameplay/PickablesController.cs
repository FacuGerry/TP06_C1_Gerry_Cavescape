using System;
using UnityEngine;
public class PickablesController : MonoBehaviour
{
    public static event Action<PickablesController> onCoinsPicked;
    public static event Action<PickablesController, int> onPlayerAddDamage;
    public static event Action<PickablesController, bool, bool, bool, bool> onPickablesMakeSound;

    [SerializeField] private PlayerDataSo data;

    [Header("Type of pickable")]
    [SerializeField] private bool isLife = false;
    [SerializeField] private bool isExtraLife = false;
    [SerializeField] private bool isCoin = false;
    [SerializeField] private bool isStrength = false;

    [Header("Stats")]
    [SerializeField] private int lifeHeal;
    [SerializeField] private int lifeAdd;
    [SerializeField] private int strengthAdd;

    private void Start()
    {
        data.currentDamage = data.damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LifePicked(collision);
        CoinPicked();
        PickablesSound();
        gameObject.SetActive(false);
    }

    public void LifePicked(Collider2D collision)
    {
        if (isLife)
        {
            if (collision.TryGetComponent(out HealthSystem healthSystem))
            {
                healthSystem.Heal(lifeHeal);
            }
        }

        if (isExtraLife)
        {
            if (collision.TryGetComponent(out HealthSystem healthSystem))
            {
                healthSystem.AddLife(lifeAdd);
            }
        }

        if (isStrength)
        {
            data.currentDamage += strengthAdd;

            if (data.currentDamage >= data.maxDamage)
                data.currentDamage = data.maxDamage;

            onPlayerAddDamage?.Invoke(this, data.currentDamage);
        }
    }

    public void CoinPicked()
    {
        if (isCoin)
        {
            onCoinsPicked?.Invoke(this);
        }
    }

    public void PickablesSound()
    {
        onPickablesMakeSound?.Invoke(this, isLife, isExtraLife, isCoin, isStrength);
    }
}
