using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_NovaExplotion : Skill
{
    float radius;
    float damage;
    ParticleSystem particle;
    GameObject skillParticle;
    public Skill_NovaExplotion(SkillUseTypes skillUse , ParticleSystem particle ,float damage ,float radius , int cost) : base(skillUse , cost)
    {
        this.particle = particle;
        this.radius = radius;
        this.damage = damage;
    }

    public override void UseSkill()
    {
        GameManager.instance.ChangeValueOfCrystal(-useCost);
        skillParticle = GameObject.Instantiate(particle, new Vector3(character.transform.position.x, character.transform.position.y + 1,
            character.transform.position.z), Quaternion.identity).gameObject;
        skillParticle.transform.parent = character.GetComponentInChildren<Transform>();
        skillParticle.transform.Rotate(-90, 0, 0);
        skillParticle.transform.localScale = new Vector3(3.333f, 3.3333f, 3.3333f);
        var sh = particle.shape;
        sh.radius = 10;
        GameObject.Destroy(skillParticle, 1f);
        Collider[] hitColliders = Physics.OverlapSphere(character.transform.position, radius, character.enemy);
        foreach (var hitCollider in hitColliders)
        {
            if (!hitCollider.gameObject.GetComponent<Character>().isDead)
            {
                hitCollider.gameObject.GetComponent<Health>().GetDamage(damage);
                hitCollider.gameObject.GetComponent<Animator>().SetTrigger("isKnocked");
            }
        }
    }
}
