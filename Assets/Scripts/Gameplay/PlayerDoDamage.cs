using System;
using UnityEngine;

public class PlayerDoDamage : MonoBehaviour
{
    public static event Action<PlayerDoDamage> onPlayerDoDamage;

    [SerializeField] private PlayerDataSo data;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.DoDamage(data.currentDamage);
            onPlayerDoDamage?.Invoke(this);
        }
    }
}
