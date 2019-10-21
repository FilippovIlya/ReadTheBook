using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panelMage;
    public GameObject panelArcher;
    public GameObject panelAssasin;
    public GameObject panelKnight;
    public void BtnExitGame()
    {
        //save game and exit
        
        Application.Quit();
    }
    public void GameLoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
