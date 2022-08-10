using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillButton : MonoBehaviour, IDeselectHandler, IPointerDownHandler, IPointerUpHandler 
{
    
    TextMeshProUGUI text;
    Skill mySkill;
    ParticleSystem skillParticle;
    GameObject particle;
    public FixedJoystick aimJoystick;
    float timer = 0;
    bool isPressed = false;
    PointerEventData pointerDownData;
    PointerEventData pointerUpData;
    public void SetSkill(Skill skill)
    {
        mySkill = skill;
        Debug.Log("setskill "+ text);
        Debug.Log("set skill " + skill);

        /*
        GetComponent<Button>().onClick.AddListener(() => {
            mySkill.UseSkill();
            GetComponent<CooldownSkill>().StartCooldDown();            
        });
        */
    }

    private void Update()
    {
        /*Debug.Log(mySkill);
        Debug.Log(mySkill.skillUseType);
        Debug.Log(mySkill + " " + Skill.SkillUseTypes.HoldToUse + "isp" + isPressed); */
        if (mySkill.skillUseType == Skill.SkillUseTypes.HoldToUse  && !isPressed)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }            
        }


        if (mySkill.skillUseType == Skill.SkillUseTypes.HoldToAim)
        {
            if (isPressed)
            {
                timer += Time.deltaTime;
                if (timer > 0.15f)
                {
                    aimJoystick.gameObject.SetActive(true);
                    if (timer > 0.20f)
                    {
                        aimJoystick.OnPointerDown(pointerDownData);
                        mySkill.SetSkillDirection(new Vector3(aimJoystick.Direction.x, 0, aimJoystick.Direction.y));
                    }
                }
                else
                {
                    if (GameManager.instance.player.GetClosestEnemy() != null)
                    {
                        mySkill.SetSkillDirection((GameManager.instance.player.GetClosestEnemy().position - GameManager.instance.player.transform.position).normalized);
                    }
                    else
                    {
                        mySkill.SetSkillDirection(GameManager.instance.player.transform.forward);
                    }

                }

            }

        }
        else if (mySkill.skillUseType == Skill.SkillUseTypes.HoldToUse)
        {
            if (isPressed)
            {
                
                if (timer < mySkill.energyTimer)
                {
                    timer += Time.deltaTime;
                    UseSkill();
                }
                else
                {
                    // ??
                }
            }

        }
        else if (mySkill.skillUseType == Skill.SkillUseTypes.ClickToUse)
        {

        }
    }


    /* public void OnUpdateSelected(BaseEventData eventData)
    {


    }*/

    public void OnDeselect(BaseEventData eventData)
    {
        if(aimJoystick != null)
        {
            aimJoystick.OnPointerUp(pointerUpData);
        }               
    }

    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
        if(mySkill.skillUseType == Skill.SkillUseTypes.HoldToUse)
        {            
            particle = Instantiate(mySkill.particleEffect, GameManager.instance.player.transform);
            particle.transform.position = GameManager.instance.player.transform.position;
            particle.transform.localScale = new Vector3(3, 3, 3);
        }
        pointerDownData = data;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
        if (mySkill.skillUseType == Skill.SkillUseTypes.ClickToUse || mySkill.skillUseType == Skill.SkillUseTypes.HoldToAim)
        {
            if (aimJoystick != null)
            {
                aimJoystick.gameObject.SetActive(false);
            }
            timer = 0;
            if (GetComponent<Button>().interactable == true)
            {
                UseSkill();
            }
        } else if(mySkill.skillUseType == Skill.SkillUseTypes.HoldToUse)
        {
            Destroy(particle);
        }
    }

    public void UseSkill()
    {
        mySkill.UseSkill();
        GetComponent<CooldownSkill>().StartCooldDown();
    }

    public void CheckUsable() // Cost Check Gerek yok !
    {
        if(GameManager.instance.crystalCount >= mySkill.useCost && !GetComponent<CooldownSkill>().isCoolDown)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }

    void HoldToUse()
    {

    }

    void HoldToAim()
    {

    }

    void ClickToUse()
    {

    }
}
