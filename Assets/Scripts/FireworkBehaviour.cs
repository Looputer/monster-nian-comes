using UnityEngine;

public class FireworkBehaviour : MonoBehaviour
{
    public static ParticleSystem FireworkParticles;
    void Start()
    {
        FireworkParticles = GetComponent<ParticleSystem>();
        FireworkParticles.Stop();
    }
}
