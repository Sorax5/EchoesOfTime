using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class RewindController : Chronometer
{

    private Stack<Vector3> positions;
    
    [SerializeField]
    private bool isRewinding = false;
    [SerializeField]
    private bool isRecording = false;

    private PlayerController playerController;
    
    private TrailRenderer trailRenderer;
    
    private Rigidbody2D rb;
    
    [SerializeField]
    private RewindImage rewindImage;

    private void Awake()
    {
        positions = new Stack<Vector3>();
        trailRenderer = GetComponent<TrailRenderer>();
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        eachIteration();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartChronometer();
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        
        if(isRecording)
        {
            record();
        }
    }

    private void startRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
        playerController.enabled = false;
        rewindImage.startRewind();
    }
    
    private void stopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
        playerController.enabled = true;
        rewindImage.stopRewind();
    }
    
    private void startRecord()
    {
        isRecording = true;
        rewindImage.startRecord();
    }
    
    private void stopRecord()
    {
        isRecording = false;
        rewindImage.stopRecord();
    }

    private void record()
    {
        positions.Push(transform.position);
    }
    
    private void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions.Pop();
        }
        else
        {
            stopRewind();
        }
    }
    
    public override void End()
    {
        stopRecord();
        startRewind();
    }

    public override void Begin()
    {
        startRecord();
    }
}
