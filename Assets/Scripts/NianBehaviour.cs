using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NianBehaviour : MonoBehaviour
{
    private int _emeryLifes;
    public GameObject player;
    public GameObject fireBall;
    public float fireSpeed = 35f;
    public float updateInterval = 2.5f;
    public float nextUpdateAllowedTime;
    public int EmeryLifes
    {
        get { return _emeryLifes; }
        set
        {
            _emeryLifes = value;
            if (_emeryLifes <= 0)
            {
                Destroy(gameObject);
                FireworkBehaviour.FireworkParticles.Play();
            }
        }
    }
    void Start()
    {
        nextUpdateAllowedTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= nextUpdateAllowedTime)
        {
            
            transform.LookAt(player.transform);
            GameObject newFireBall = Instantiate(fireBall, transform.position + Vector3.right, transform.rotation) as GameObject;
            Rigidbody fireBallRB = newFireBall.GetComponent<Rigidbody>();
            fireBallRB.velocity = transform.forward * fireSpeed;
            nextUpdateAllowedTime = Time.time + updateInterval;
        }
    }
    
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Money(Clone)")
        {
            EmeryLifes--;
            Debug.Log(EmeryLifes);
        }
    }
    
}
