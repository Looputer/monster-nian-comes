using UnityEngine;

public class FireBallBehaviour : MonoBehaviour
{
    public float onscreenDelay = 1.5f;

    void Start()
    {
        Destroy(gameObject, onscreenDelay);
    }
}
