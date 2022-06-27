using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class SetupScript : MonoBehaviour
{
    //attribut textManche qui sera le texte de la manche
    public Text textManche;
    
    //attribut textEventMancheEnd qui sera le texte de la manche
    public Text textEventMancheEnd;
    
    //attribut chronoManche qui sera le texte de la manche
    public Text ChronoManche;
    
    //attribut NewManche qui sera le texte de la manche
    public Text NewManche;
    
    public Transform CrocoContainer;
    
    // Start is called before the first frame update
    void Start()
    {
        MancheScript.PV_Is_Spawn = false;
        textManche.gameObject.SetActive(true);
        textEventMancheEnd.gameObject.SetActive(false);
        ChronoManche.gameObject.SetActive(true);
        NewManche.gameObject.SetActive(true);
        MancheScript.timeRemaining = 6f;
        MancheScript.ChronoTime = true;
        MancheScript.isSpawned = false;
       
        MancheScript.NbManche = 0;
        MancheScript.nbEnnemyCourant = 0;
        HealthBar.FullBar();

        foreach (Transform child in CrocoContainer)
        {
            Destroy(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Permet de rendre invisible le curseur
        Cursor.visible = false;
        //Permet de figer le curseur au milieu de l'écran
        Cursor.lockState = CursorLockMode.Locked;
    }
}
