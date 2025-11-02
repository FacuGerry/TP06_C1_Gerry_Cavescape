using System;
using UnityEngine;

public class OrbCounter : MonoBehaviour
{
    public static event Action<OrbCounter> onOrbPicked;

    [SerializeField] private OrbController controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller.numOfOrbs++;
        onOrbPicked?.Invoke(this);
        gameObject.SetActive(false);
    }
}
