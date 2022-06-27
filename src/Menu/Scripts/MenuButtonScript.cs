using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    public void Jouer(){
        //Lancement de la Scene du panel des niveaux
        SceneManager.LoadScene("Game");
    }

    public void Quitter(){
        //Ferme l'application
        Application.Quit();
    }

}
