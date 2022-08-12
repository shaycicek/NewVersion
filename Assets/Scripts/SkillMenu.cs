using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillMenu : MonoBehaviour
{
    public TextMeshProUGUI tmesh;
    public static bool SkillUsed = false;
    public ParticleSystem novaExplotionParticle;
    public ParticleSystem speedParticle;
    public ParticleSystem damageMultipleParticle;
    public GameObject whirlWindParticle;

    Character player;
    Skill spawnSkill;
    Skill damageMultipSkill;
    Skill novaSkill;
    Skill speedSkill;
    Skill dashSkill;
    Skill whirlWind;
    public SkillButton novaExplotion;    
    public SkillButton dashButton;
    public SkillButton whirlwindButton;

    public List<SkillButton> skillButtons = new List<SkillButton>();
    public static SkillMenu instance;
    List<Skill> skills = new List<Skill>();

    private void Awake()
    {
        if(instance == null || instance == this)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Update is called once per frame
    private void Start()
    {
        dashSkill = new Skill_Dash(Skill.SkillUseTypes.HoldToAim, 2, 1);
        dashSkill.Initialize(GameManager.instance.player);

        whirlWind = new Skill_Whirlwind(whirlWindParticle, 5, .1f , Skill.SkillUseTypes.HoldToUse, 5, 1); // DAMAGE ÝÇÝN FARKLI BÝR ÞEY DÜÞÜNÜLEBÝLÝR
        whirlWind.Initialize(GameManager.instance.player);

        novaSkill = new Skill_NovaExplotion(Skill.SkillUseTypes.ClickToUse , novaExplotionParticle , 15, 10, 1);
        novaSkill.Initialize(GameManager.instance.player);

        skills.Add(novaSkill);
        skills.Add(dashSkill);
        skills.Add(whirlWind);
        skillButtons[0].SetSkill(skills[0]);
        skillButtons[0].SetSkill(skills[1]);
        skillButtons[0].SetSkill(skills[2]);
        for (int i = 0; i < skillButtons.Count; i++)
        {
            Skill s = skills[i];
            skillButtons[i].SetSkill(s);

        }

        player = GameManager.instance.player;

    }
    
    public void InitializeSkillMenu()
    {
        GameManager.instance.OnMineralCollect += CheckUsable;
    }

    private void OnDisable()
    {
        //KONTROL ET
        GameManager.instance.OnMineralCollect -= CheckUsable;
    }

    public void CheckUsable()
    {
        foreach(SkillButton sb in skillButtons)
        {
            sb.CheckUsable();
        }
    }
}
