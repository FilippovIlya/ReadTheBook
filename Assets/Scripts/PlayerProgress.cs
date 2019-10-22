using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{
    //стартовая специализация
    public bool isWizard;
    //специализация ледяного мага
    public bool isIceWizard;
    //специализация огненного мага
    public bool isFireWizard;
    //аниматоры для разных специализация
    public RuntimeAnimatorController[] controllers;
    //спайты скиллов идут по 3, то есть [0] [1] [2] это стартовая специализация, [3] [4] [5] это ледяной маг
    public Sprite[] skills;
    // текстовое поле при смене специализации - в дальнешем поменять на анимацию или еще чето крутое
    public GameObject txt;
    // максимум здоровья игрока
    [HideInInspector] public float maxLife = 100;
    //здоровье от экипировки
    [HideInInspector] public float maxLifeFromEQ;
    //текущее здоровье
     public float curLife;
    //текущий уровень
    [HideInInspector] public float level = 1;
    //опыт необходимый для получения следующего уровня
    [HideInInspector] public float nextLevelExp = 1000;
    //текущий опыт
    [HideInInspector] public float curExp = 0;
    //броня игрока
    [HideInInspector] public float armor;
    //броня от экипировки
    [HideInInspector] public float armorFromEQ;
    //ссылка на аниматор
    private Animator animator;
    //выводим уровень на экран
    private Text Level_Text;
    //выводим текущий опыт слайдером
    private Slider EXP_Slider;
    //выводим текущее здоровье слайдером
    private Slider HP_Slider;
    //выводим текущую ману слайдером
    private Slider Mana_Slider;
    //текущая мана
    [HideInInspector] public float curMana=100;
    //максимум маны
    [HideInInspector] public float maxMana;
    //мана от экипа
    [HideInInspector] public float maxManaFromEQ;
    //реген маны
    [HideInInspector] public float manaRegen=5;
    //реген здоровья
    [HideInInspector] public float lifeRegen=25;
    //мана реген от амулета
    [HideInInspector] public float manaRegenFromAmulet;
    //мана реген от брони
    [HideInInspector] public float manaRegenFromArmor;
    //ссылка на скилл1 для установки спрайта в иконку
    public GameObject skill1;
    //ссылка на скилл2 для установки спрайта в иконку
    public GameObject skill2;
    //ссылка на скилл3 для установки спрайта в иконку
    public GameObject skill3;
    //ссылка на рюкзак
    private BackPack backPack;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        backPack = GameObject.FindGameObjectWithTag("GameController").GetComponent<BackPack>();
        backPack.itemChanged.AddListener(StatsChange);
        Level_Text = GameObject.Find("levelLabel").GetComponent<Text>();
        EXP_Slider = GameObject.Find("Exp").GetComponent<Slider>();
        HP_Slider = GameObject.Find("HP").GetComponent<Slider>();
        Mana_Slider = GameObject.Find("Mana").GetComponent<Slider>();
        StartCoroutine(ManaRegen());
        StartCoroutine(LifeRegen());
        maxManaFromEQ = gameObject.GetComponent<Equip>().mana;
        maxLifeFromEQ = gameObject.GetComponent<Equip>().health;
        manaRegenFromAmulet = gameObject.GetComponent<Equip>().manaregenFromAmulet;
        manaRegenFromArmor = gameObject.GetComponent<Equip>().manaregenfromArmor;
        armorFromEQ = gameObject.GetComponent<Equip>().armor;
    }
    void Update()
    {
        //формулы для расчета статов - перенести в функцию и запускать от ивентов в дальнейшем вроде сделал - протестить все норм потом
        //maxLife = 1000 + level * 100 + maxLifeFromEQ;
        //armor = 1 + level * 0.1f + armorFromEQ;
        //maxMana = 500 + level * 50 + maxManaFromEQ;
        //manaRegen = 5 + level * 1 + manaRegenFromAmulet + manaRegenFromArmor;
        //lifeRegen = 25 + level * 2;
        //обновление панельки ХП МАНА ЭКСП ЛВЛ
        HP_Slider.value = curLife / maxLife;
        EXP_Slider.value = curExp / nextLevelExp;
        Level_Text.text = level.ToString();
        Mana_Slider.value = curMana/maxMana;
        //апаем уровень увеличиваем необходимую экспу, текущую ставим в 0
        if (curExp >= nextLevelExp)
        {
            level++;
            curExp = 0;
            nextLevelExp *= 2;
         
        }
        

    }
    //меняем статы игрока когда надели шмотку новую
    public void StatsChange()
    {
        maxManaFromEQ = gameObject.GetComponent<Equip>().mana;
        maxLifeFromEQ = gameObject.GetComponent<Equip>().health;
        manaRegenFromAmulet = gameObject.GetComponent<Equip>().manaregenFromAmulet;
        manaRegenFromArmor = gameObject.GetComponent<Equip>().manaregenfromArmor;
        armorFromEQ = gameObject.GetComponent<Equip>().armor;
        maxLife = 1000 + level * 100 + maxLifeFromEQ;
        armor = 1 + level * 0.1f + armorFromEQ;
        maxMana = 500 + level * 50 + maxManaFromEQ;
        manaRegen = 5 + level * 1 + manaRegenFromAmulet + manaRegenFromArmor;
        lifeRegen = 25 + level * 2;
    }
    //меняем специализацию на стартовую
    public void ChangeSpecialisationWizard()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null) {
            txt.SetActive(true);
            StartCoroutine(ChangeWizard());
        }
        
    }
    //меняем специализацию на ледяного мага
    public void ChangeSpecialisationIceWizard()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            txt.SetActive(true);
            StartCoroutine(ChangeIceWizard());
        }
    }
    //меняем специализацию на огненного мага
    public void ChangeSpecialisationFireWizard()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            txt.SetActive(true);
            StartCoroutine(ChangeFireWizard());
        }
    }
    //меняем специализацию на стартовую
    IEnumerator ChangeWizard()
    {
        yield return new WaitForSeconds(5);
        isIceWizard = false;
        isFireWizard = false;
        isWizard = true;
        animator.runtimeAnimatorController = controllers[0];
        skill1.GetComponent<Image>().sprite = skills[0];
        skill2.GetComponent<Image>().sprite = skills[1];
        skill3.GetComponent<Image>().sprite = skills[2];
        txt.SetActive(false);
    }
    //меняем специализацию на ледяного мага
    IEnumerator ChangeIceWizard()
    {
        yield return new WaitForSeconds(5);
        isFireWizard = false;
        isWizard = false;
        isIceWizard = true;
        animator.runtimeAnimatorController = controllers[1];
        skill1.GetComponent<Image>().sprite = skills[3];
        skill2.GetComponent<Image>().sprite = skills[4];
        skill3.GetComponent<Image>().sprite = skills[5];
        txt.SetActive(false);
    }
    //меняем специализацию на огненного мага
    IEnumerator ChangeFireWizard()
    {
        yield return new WaitForSeconds(5);
        isWizard = false;
        isIceWizard = false;
        isFireWizard = true;
        animator.runtimeAnimatorController = controllers[2];
        skill1.GetComponent<Image>().sprite = skills[6];
        skill2.GetComponent<Image>().sprite = skills[7];
        skill3.GetComponent<Image>().sprite = skills[8];
        txt.SetActive(false);
    }
    //реген маны
    IEnumerator ManaRegen()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(ManaRegen());
        if (curMana<=maxMana) { curMana += manaRegen; }
    }
    //реген хп
    IEnumerator LifeRegen()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(LifeRegen());
        if (curLife <= maxLife) { curLife += lifeRegen; }
    }
}
