using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TypeWritter : MonoBehaviour
{
    
    [SerializeField]
    private List<String> text;
    
    [SerializeField]
    private Text textUI;
    
    [SerializeField]
    private float delay = 0.1f;

    private int index = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        textUI.text = null;
    }

    private void FixedUpdate()
    {
        
        
    }

    IEnumerator ShowLetterByLetter(String text)
    {
        for (var i = 0; i < text.Length; i++)
        {
            textUI.text += text[i];
            yield return new WaitForSeconds(delay);
        }
    }
}
