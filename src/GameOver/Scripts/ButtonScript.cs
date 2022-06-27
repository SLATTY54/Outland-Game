using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Text text;
    public void Start()
    {
        text.text = "You survived "+MancheScript.AffichageNbManche+" rounds !";
        text.gameObject.SetActive(true);
        //On rend visible le curseur et on le delock
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartButton(){
        //Si le joueur veut rejouer, on le remet sur sa précédente Scene
        SceneManager.LoadScene("Game");
    }

    public void ExitButton(){
        //Si le joueur veut "quitter", on le ramène au Menu
        SceneManager.LoadScene("Menu");
    }
}
