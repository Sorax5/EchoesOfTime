using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayClock : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_Source;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Play()
    {
        m_Source.Play();
    }
}
