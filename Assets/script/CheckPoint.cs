using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private bool isActivated = false;
    
    [SerializeField]
    private GameObject positionToRespawn;
    
    public GameObject PositionToRespawn
    {
        get => positionToRespawn;
    }
    
    public bool IsActivated
    {
        get => isActivated;
        set => isActivated = value;
    }
    
    private Collider2D coll;
    
    [SerializeField]
    private ParticleSystem ps;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (isActivated)
        {
            var main = ps.main;
            main.startColor = new ParticleSystem.MinMaxGradient(Color.green);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = true;
            
        }
    }
}
