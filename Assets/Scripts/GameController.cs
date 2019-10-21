using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //время когда умер игрок
    private float endScenetime;
    //панель поражения
    public GameObject gameOverPanel;
    // переменная для апдейта, чтобы конец игры вызывался только один раз
    private bool onlyOneCall;
    //для конца сцены
    private bool onlyOneEndScene;
    //ссылка на игрока
    private GameObject player;
    //панель выбора специальности
    public GameObject choosespecialist;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        //контроль конца игры
        if (player.GetComponent<PlayerProgress>().curLife <= 0 )
        {
            if (!onlyOneCall)
            {
                player.GetComponent<Animator>().SetBool("isDead", true);
                endScenetime = Time.time;
                onlyOneCall = true;
            }
            if( !onlyOneEndScene) endScene();
        }
    }
    public void endScene()
    {
        StartCoroutine(EndThisScene());
        GameObject.FindGameObjectWithTag("Player").GetComponent<LeftJoystickPlayerController>().enabled = false;
        onlyOneEndScene = true;
        
    }
    //кнопка рестарта
    public void BtnRestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //кнопка выбора специальности
    public void ChooseBtn()
    {

        if (choosespecialist.activeSelf == true)
        {
            choosespecialist.SetActive(false);
        }
        else
        {
            choosespecialist.SetActive(true);
        }

    }
    IEnumerator EndThisScene()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        onlyOneEndScene = true;
    }

}
