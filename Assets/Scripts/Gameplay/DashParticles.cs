using System.Collections;
using UnityEngine;

public class DashParticles : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private float particlesDuration;
    private IEnumerator particleLoop;

    private void OnEnable()
    {
        PlayerController.onPlayerDash += OnPlayerDash_ParticlesAppear;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerDash -= OnPlayerDash_ParticlesAppear;
    }

    public void OnPlayerDash_ParticlesAppear(PlayerController playerController)
    {
        if (particleLoop != null)
            StopCoroutine(particleLoop);

        particleLoop = ParticleLooping();
        StartCoroutine(particleLoop);
    }

    public IEnumerator ParticleLooping()
    {
        particles.SetActive(true);
        yield return new WaitForSeconds(particlesDuration);
        particles.SetActive(false);
    }
}
