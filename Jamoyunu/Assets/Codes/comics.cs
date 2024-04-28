using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comics : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    [SerializeField] AudioSource[] sources;
    int index = 1;
    void Start()
    {
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }
        panels[0].SetActive(true);
        openthissong(0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (index == 1)
            {
                openthissong(1);
            }
            if (index == 4)
            {
                openthissong(2);
            }
            if (index < panels.Length)
            {
                transform.DOMove(panels[index].transform.position + Vector3.forward * -10, 0.75f);
                panels[index].SetActive(true);

            }
            index++;
        }


        if (index == panels.Length + 1)
        {
            SceneManager.LoadScene("SampleScenea");
        }

    }
    public void openthissong(int num)
    {
        for (int i = 0; i < 3; i++)
        {
            sources[i].enabled = false;
        }
        sources[num].enabled = true;
    }
}
