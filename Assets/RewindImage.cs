using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewindImage : MonoBehaviour
{
    
    [SerializeField] private GameObject rewind;
    public GameObject Rewind
    {
        get => rewind;
    }

    [SerializeField] private GameObject record;
    public GameObject Record
    {
        get => record;
    }
    
    [SerializeField] private Animator rewindAnimator;
    [SerializeField] private Animator recordAnimator;
    
    private Image rewindImage;
    private Image recordImage;
    
    [SerializeField]
    private ParticleSystem rewindParticles;

    private void Awake()
    {
        rewindImage = rewind.GetComponent<Image>();
        recordImage = record.GetComponent<Image>();
        rewindParticles.Stop();
    }
    
    public void startRewind()
    {
        rewindAnimator.SetTrigger("start");
    }
    
    public void stopRewind()
    {
        rewindAnimator.SetTrigger("end");
        rewindParticles.Stop();
    }

    public void startRecord()
    {
        recordAnimator.SetTrigger("start");
        rewindParticles.Play();
    }
    
    public void stopRecord()
    {
        recordAnimator.SetTrigger("end");
    }
}
