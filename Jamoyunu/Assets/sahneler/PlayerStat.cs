using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public float Adrenaline = 0;
    public float MaxAdrenaline;
    public float defaultlosespeed;
    public float LoseSpeed = 1;
    public float LoseSpeedTime = 1;
    private float LoseSpeedTimer = 0;
    private float firetime = 0;
    public float firetimer = 1;
    public float JumpForge = 2;
    public GameObject ProjectTile;
    public GameObject adrenalineBar;
    public bool Immortal = false;
    public float ImmortalTime = 0;
    private float ImmortalTimer = 0;
    public float TimeScaleTime = 0;
    private float TimeScaleTimer = 0;
    [Header("ItemPicked")]
    public bool medkit;
    public bool  apple, energydr, mushroom, fire;
    void Update()
    {
        Adrenaline = Mathf.Clamp(Adrenaline, -Mathf.Infinity, MaxAdrenaline);
        if (mushroom)
        {
            ImmortalTimer += Time.deltaTime;
            if (ImmortalTimer >= ImmortalTime)
            {
                mushroom = false;
                Immortal = false;
                ImmortalTimer = 0;
            }
        }
        if (energydr)
        {
            TimeScaleTimer += Time.deltaTime;
            if (TimeScaleTimer >= TimeScaleTime)
            {
                energydr = false;
                Time.timeScale = 1;
                TimeScaleTimer = 0;
            }
        }
        if (medkit)
        {
            LoseSpeedTimer += Time.deltaTime;
            if (LoseSpeedTimer >= LoseSpeedTime)
            {
                medkit = false;
                LoseSpeed = defaultlosespeed;
                LoseSpeedTimer = 0;
            }
        }
        if (fire)
        {
            firetime += Time.deltaTime;
            if (firetime >= firetimer)
            {
                fire = false;
                LoseSpeed = defaultlosespeed;
                firetime = 0;
            }
        }
        Adrenaline -= LoseSpeed * Time.deltaTime;
        adrenalineBar.GetComponent<Image>().fillAmount = Adrenaline / MaxAdrenaline;
}

}
