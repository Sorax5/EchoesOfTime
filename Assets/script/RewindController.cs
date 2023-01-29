using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = System.Numerics.Vector2;

public class RewindController : Chronometer
{

    private Stack<Vector3> positions;
    
    [SerializeField]
    private bool isRewinding = false;
    [SerializeField]
    private bool isRecording = false;

    private PlayerController playerController;

    private Rigidbody2D rb;
    
    [SerializeField]
    private RewindImage rewindImage;
    
    private List<GameObject> remanentObjects = new List<GameObject>();
    
    private Vector3 lastPosition;
    
    [SerializeField]
    private Slider slider;

    private void Awake()
    {
        positions = new Stack<Vector3>();
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        slider.maxValue = MaxTime;
        slider.value = Time;
        lastPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(!isRecording && !isRewinding)
                StartChronometer();
            else if(isRecording)
                StopChronometer();
        }
    }

    private void FixedUpdate()
    {
        eachIteration();
        if (isRewinding)
        {
            Rewind();
            slider.value--;
        }
        
        if(isRecording)
        {
            record();
            slider.value++;
        }

        if (isRecording || isRewinding)
        {
            // retrive GameObject of the slider component
            GameObject sliderObject = slider.gameObject;
        }
        else
        {
            GameObject sliderObject = slider.gameObject;
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
        Vector3 position = transform.position;
        
        // verifying if position & last position are the same
        if (position == lastPosition)
        {
            return;
        }
        
        if (positions.Count % 10 == 0)
        {
            // create copy of the player without children & components
            GameObject remanent = Instantiate(gameObject, position, Quaternion.identity);
            // remove all components
            foreach (Component component in remanent.GetComponents<Component>())
            {
                if (!(component is Transform || component is SpriteRenderer))
                {
                    Destroy(component);
                }
            }
            
            // set color to gray & transparency to 0.5
            remanent.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            
            // remove all children
            foreach (Transform child in remanent.transform)
            {
                Destroy(child.gameObject);
            }
            remanentObjects.Add(remanent);   
        }
        positions.Push(position);
        
        lastPosition = position;
        
    }
    
    private void Rewind()
    {
        if (positions.Count > 0)
        {
            Vector3 position = positions.Pop();
            
            if(positions.Count % 10 == 0)
            {
                GameObject remanent = remanentObjects[remanentObjects.Count - 1];
                remanentObjects.Remove(remanent);
                Destroy(remanent);
            }

            rb.MovePosition(position);
        }
        else
        {
            stopRewind();
        }
    }
    
    public override void End()
    {
        if(Time != MaxTime)
            startRewind();
        else
            explodRemanent();
        stopRecord();
    }

    public override void Begin()
    {
        positions.Clear();
        startRecord();
    }

    private void explodRemanent()
    {
        for (var i = 0; i < remanentObjects.Count; i++)
        {
            GameObject remanent = remanentObjects[i];
            Destroy(remanent, 1);
        }
    }
}
