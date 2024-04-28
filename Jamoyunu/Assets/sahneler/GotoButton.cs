using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GotoButton : MonoBehaviour
{
    [SerializeField]
    public string scene;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => {Goto(scene);});
    }
    void Goto(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        Time.timeScale = 1;
        SceneManager.LoadScene(scenename);
    }
}
