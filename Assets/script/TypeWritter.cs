using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeWritter : MonoBehaviour
{
    
    [SerializeField]
    private List<String> texts;
    
    [SerializeField]
    private TextMeshProUGUI textUI;
    
    [SerializeField]
    private float delay = 0.1f;
    
    [SerializeField]
    private Animator animator;

    private int index = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        textUI.text = null;
        index = 0;
        StartCoroutine(ShowLetterByLetter(texts[index]));
    }

    IEnumerator ShowLetterByLetter(String text)
    {
        yield return new WaitForSeconds(1f);
        for (var i = 0; i < text.Length; i++)
        {
            textUI.text += text[i];
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1.5f);
        textUI.text = null;
        index++;
        if (index < texts.Count)
        {
            StartCoroutine(ShowLetterByLetter(texts[index]));
        }
        else
        {
            animator.SetTrigger("start");
            StartCoroutine(changeScene());
        }
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(8F);
        SceneManager.LoadScene(0);
    }
}
