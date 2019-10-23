using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTile : MonoBehaviour
{
    public string nameScene; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameLoadScene(nameScene);
           
        }
    }
    public void GameLoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
