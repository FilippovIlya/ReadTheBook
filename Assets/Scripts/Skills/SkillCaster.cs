using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class SkillCaster : MonoBehaviour
{
    //ссылка на аниматор
    private Animator animator;
    //ссылка на экип
    private Equip equip;
    //ссылка на рюкзак
    private BackPack backPack;
    //ссылка на прогресс игрока
    private PlayerProgress pp;
    //кд скилла1 стартовой спеки
    public float cooldownSkillOneWizard;
    //время когда скастован скилл
    private float skillOneCastTime;
    //кд скилла1 ледяного мага
    public float cooldownSkillOneIceWizard;
    ////время когда скастован скилл
    private float skillOneIceCastTime;
    // кд скилла 2 стартовой спеки
    public float cooldownSkillTwoWizard;
    ////время когда скастован скилл
    private float skillTwoCastTime;
    // кд скилла 2 ледяного мага
    public float cooldownSkillTwoIceWizard;
    ////время когда скастован скилл
    private float skillTwoIceCastTime;
    //кд скилла 3 стартовой
    public float cooldownSkillThreeWizard;
    ////время когда скастован скилл
    private float skillThreeCastTime;
    //кд скилла 3 ледяного мага
    public float cooldownSkillThreeIceWizard;
    ////время когда скастован скилл
    private float skillThreeIceCastTime;
    //кд скилла 1 огненного
    public float cooldownSkillOneFireWizard;
    ////время когда скастован скилл
    private float skillOneFireCastTime;
    //кд скилла 2 огненного
    public float cooldownSkillTwoFireWizard;
    ////время когда скастован скилл
    private float skillTwoFireCastTime;
    //кд скилла 3 огненного
    public float cooldownSkillThreeFireWizard;
    ////время когда скастован скилл
    private float skillThreeFireCastTime;
   
    //мана необходимая на скиллы
    public float mana1W;
    public float mana2W;
    public float mana3W;
    public float mana1IW;
    public float mana2IW;
    public float mana3IW;
    public float mana1FW;
    public float mana2FW;
    public float mana3FW;
    private void Start()
    {
        backPack = GameObject.FindGameObjectWithTag("GameController").GetComponent<BackPack>();
        equip = gameObject.GetComponent<Equip>();
        animator = gameObject.GetComponent<Animator>();
        pp = gameObject.GetComponent<PlayerProgress>();

    }
   
    public void SkillOneWizard()
    {
        //когда сделаешь шмотки влияющие на скиллы добавить if(equip.weapontype№) {}
        if (gameObject.GetComponent<PlayerProgress>().isWizard == true)
        {
            if (GameObject.FindGameObjectWithTag("Enemy") != null )
            {
                if (cooldownSkillOneWizard <= Time.time - skillOneCastTime && pp.curMana >= mana1W)
                {
                    skillOneCastTime = Time.time;
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isIdle", false);
                    PoolObject skillOne = PoolManager.Get(3);
                    skillOne.transform.position = transform.position;
                    pp.curMana -= mana1W;
                }
            }
        }
        if (gameObject.GetComponent<PlayerProgress>().isIceWizard == true)
        {
            
                if (cooldownSkillOneIceWizard <= Time.time - skillOneIceCastTime && pp.curMana >= mana1IW)
                {
                skillOneIceCastTime = Time.time;
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isIdle", false);
                    PoolObject skillOneIce = PoolManager.Get(6);
                    skillOneIce.transform.position =  new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.6f); 
                pp.curMana -= mana1IW;
            }
            
        }
        if (gameObject.GetComponent<PlayerProgress>().isFireWizard == true)
        {
            if (GameObject.FindGameObjectWithTag("Enemy") != null)
            {
                if (cooldownSkillOneFireWizard <= Time.time - skillOneFireCastTime && pp.curMana >= mana1FW)
                {
                    skillOneFireCastTime = Time.time;
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isIdle", false);
                    PoolObject skillOneFire = PoolManager.Get(9);
                    skillOneFire.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.6f);
                    pp.curMana -= mana1FW;
                }
            }
        }
    }
    public void SkillTwoWizard()
    {
        //когда сделаешь шмотки влияющие на скиллы добавить if(equip.weapontype№) {}
        if (gameObject.GetComponent<PlayerProgress>().isWizard == true)
        {
            if (cooldownSkillTwoWizard <= Time.time - skillTwoCastTime && pp.curMana >= mana2W)
            {
                skillTwoCastTime = Time.time;
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", false);
                PoolObject skillTwo = PoolManager.Get(4);
                skillTwo.transform.position = transform.position;
                pp.curMana -= mana2W;
            }
        }
        if (gameObject.GetComponent<PlayerProgress>().isIceWizard == true)
        {
            if (cooldownSkillTwoIceWizard <= Time.time - skillTwoIceCastTime && pp.curMana >= mana2IW)
            {
                skillTwoIceCastTime = Time.time;
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", false);
                PoolObject skillTwoIce = PoolManager.Get(7);
                skillTwoIce.transform.position = transform.position;
                pp.curMana -= mana2IW;
            }
        }
        if (gameObject.GetComponent<PlayerProgress>().isFireWizard == true)
        {
            if (cooldownSkillTwoFireWizard <= Time.time - skillTwoFireCastTime && pp.curMana >= mana2FW)
            {
                skillTwoFireCastTime = Time.time;
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", false);
                PoolObject skillTwoFire = PoolManager.Get(10);
                skillTwoFire.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.6f);
                pp.curMana -= mana2FW;
            }
        }
    }
    public void SkillThreeWizard()
    {
        //когда сделаешь шмотки влияющие на скиллы добавить if(equip.weapontype№) {}
        if (gameObject.GetComponent<PlayerProgress>().isWizard == true)
        {
            if (cooldownSkillThreeWizard <= Time.time - skillThreeCastTime && pp.curMana >= mana3W)
            {
                skillThreeCastTime = Time.time;
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", false);
                PoolObject skillThree = PoolManager.Get(5);
                skillThree.transform.position = transform.position;
                pp.curMana -= mana3W;
            }
        }
        if (gameObject.GetComponent<PlayerProgress>().isIceWizard == true)
        {
            if (cooldownSkillThreeIceWizard <= Time.time - skillThreeIceCastTime && pp.curMana >= mana3IW)
            {
                skillThreeIceCastTime = Time.time;
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", false);
                PoolObject skillThreeIce = PoolManager.Get(8);
                pp.curMana -= mana3IW;
            }
        }
        if (gameObject.GetComponent<PlayerProgress>().isFireWizard == true)
        {
            if (cooldownSkillThreeFireWizard <= Time.time - skillThreeFireCastTime && pp.curMana >= mana3FW)
            {
                skillThreeFireCastTime = Time.time;
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", false);
                PoolObject skillThreeFire = PoolManager.Get(11);
                skillThreeFire.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.6f);
                pp.curMana -= mana3FW;

            }
        }
    }
}
