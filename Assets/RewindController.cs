using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class RewindController : MonoBehaviour
{

    private Stack<Vector3> positions;
    
    [SerializeField]
    private bool isRewinding = false;
    [SerializeField]
    private bool isRecording = false;

    [SerializeField]
    private int time = 0;
    private int maxTime = 1000;
    
    private PlayerController playerController;
    
    private TrailRenderer trailRenderer;
    
    private Rigidbody2D rb;

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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            startRecord();
        }

        if (isRecording)
        {
            time++;
        }
        
        if(time >= maxTime)
        {
            stopRecord();
            startRewind();
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
        
    }
    
    private void stopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
        playerController.enabled = true;
    }
    
    private void startRecord()
    {
        isRecording = true;
        time = 0;
    }
    
    private void stopRecord()
    {
        isRecording = false;
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
}
