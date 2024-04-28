using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] GameObject LosePanel;
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] TextMeshProUGUI scoretxtingame;
    public bool died;
    public float KillCounter;
    public float score;
    public Volume m_Volume;
    public Vignette m_LensDistortion;
    public float multipleint;
    public float multipleScore;
    public float Adrenaline = 0;
    public float MaxAdrenaline;
    public float defaultlosespeed;
    public float LoseSpeed = 1;
    public float LoseSpeedTime = 1;
    private float LoseSpeedTimer = 0;
    private float firetime = 0;
    public GameObject fireparticle;
    public float firetimer = 1;
    public float JumpForge = 2;
    public float firsttime;
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
    private void Start()
    {
        firsttime = Time.time;
    }
    void Update()
    {
        if (Adrenaline <= 0&&!Immortal&&!died)
        {
            died = true;
            die();
        }
        score += Time.deltaTime*multipleScore;
        scoretxtingame.text = "öldürme sayýsý: "+KillCounter+"\n geçen zaman: "+(Time.time-firsttime).ToString("0") + "\n skor: " + score.ToString("0") ;
        m_Volume.profile.TryGet(out m_LensDistortion);
        m_LensDistortion.intensity.value = (1-Adrenaline/MaxAdrenaline)*multipleint;
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
            fireparticle.SetActive(true);
            firetime += Time.deltaTime;
            if (firetime >= firetimer)
            {
                fire = false;
                LoseSpeed = defaultlosespeed;
                firetime = 0;
            }
        }
        else { fireparticle.SetActive(false); }
        Adrenaline -= LoseSpeed * Time.deltaTime;
        adrenalineBar.GetComponent<Image>().fillAmount = Adrenaline / MaxAdrenaline; 

}
    public void die()
    {
        
        Time.timeScale = 0;
        LosePanel.SetActive(true);
        scoretext.text = "öldürme sayýsý: " + KillCounter + "\ngeçen zaman: " + Time.time.ToString("0") + "\nskor: " + score.ToString("0");

    }

}
