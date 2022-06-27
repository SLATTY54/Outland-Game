using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarScript : MonoBehaviour
{
    public Image barImage;
    public Animator persos_Animator;

    public static bool isDead;

    private void Awake(){
        //On récupere l'image de la barre d'eau
        barImage = transform.Find("Bar").GetComponent<Image>();
    }

    void Update(){
        
        

        //Permet de modifier la taille de l'image de façon horizontale selon le resultat de notre méthode
        barImage.fillAmount = HealthBar.GetWaterNormalized();
        //Si le resultat de la méthode est inférieur ou égal à 0, notre joueur est mort de soif
        
        if(HealthBar.PV_c <= 0f)
        {


            StartCoroutine(End());

        }
        
    }

    IEnumerator End()
    {
        if (!isDead)
        {
            persos_Animator.Play("Die");
            isDead = true;
        }
        
        yield return new WaitForSeconds(0.35f);
        isDead = false;
        SceneManager.LoadScene("GameOverScreen");
        
    }
}

public class HealthBar {

    //Constante qui indique le montant maximum d'eau qu'on puisse avoir
    public const int PV = 100;

    //Attribut qui correspond au montant d'eau que l'on a
    public static float PV_c = 100;
    
    

    

    //Sur Unity la taille de l'image de la barre est compris entre 0 et 1.
    // 0 --> L'image est invisible 
    // 1 --> L'image prend l'intégralité de la zone qui lui est dédié (horizontalement)
    // Ce calcul permet d'avoir un nombre entre 0 et 1 pour modifier la taille de barre
    public static float GetWaterNormalized(){
        return PV_c / PV;
    }

    //Permet de remonter notre niveau d'eau au MAX.
    public static void FullBar(){
        PV_c = PV;
    }
}
