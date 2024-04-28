using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class comics : MonoBehaviour
{
    [SerializeField]
    Image[] panels;
    int index = 1;
    void Start()
    {
        foreach (var panel in panels)
        {
            panel.enabled = false;
        }
        panels[0].enabled = true;
    }

    void Update()
    {
        if (panels[index] != null && Input.GetMouseButtonDown(0))
        {
            panels[index].enabled = true;
            index++;
        }
        if (index == panels.Length)
        {
            SceneManager.LoadScene("SampleScenea");
        }
        
    }
}
