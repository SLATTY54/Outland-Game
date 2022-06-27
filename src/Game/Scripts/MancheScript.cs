using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class MancheScript : MonoBehaviour
{
    
    public static int NbManche  = 0;

    public static int AffichageNbManche = 0;

    public static bool ChronoTime;

    public static float timeRemaining = 6;

    public GameObject EnemyModel;

    public static int nbEnnemyCourant = 0;

    public Text textManche;

    public Text textEventMancheEnd;

    public Text ChronoManche;

    public Text NewManche;

    public GameObject monsterContainer;

    public static bool isSpawned;

    public GameObject PVModel;

    private GameObject PV_clone;

    public GameObject PV_cloneContainer;

    public static bool PV_Is_Spawn;

    
    /**
     * method for running the chrono
     */
    void DisplayTime(float timeToDisplay){  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        ChronoManche.text = string.Format("{0:00}:{1:00}",seconds,milliSeconds);
    }
    
    // Update is called once per frame
    void Update()
    {
        AffichageNbManche = NbManche;
        if (ChronoTime)
        {
            if (timeRemaining > 0)
            {
                //Temps que le chrono n'est pas arrivé à la fin, on le refresh
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                NbManche++;
                
                textManche.text = "Round : " + NbManche;
                ChronoManche.gameObject.SetActive(false);
                Destroy(PV_clone);
                PV_Is_Spawn = false;
                NewManche.gameObject.SetActive(false);
                StartCoroutine(EnemySpawn());
                ChronoTime = false;
            }
        
            DisplayTime(timeRemaining);
        }
        if (!ChronoTime&& isSpawned)
        {
            if (nbEnnemyCourant== 0)
            {
                StartCoroutine(Spawn());
            }
        }
    }

    /*
     * Method which makes it possible to spawn all the elements necessary at the end of each round
     */
    IEnumerator Spawn()
    {
        textEventMancheEnd.text = "Round " + NbManche + " complete !";
        textEventMancheEnd.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);

        if (!PV_Is_Spawn)
        {
            PV_clone = Instantiate(PVModel,new Vector3(Random.Range(-22.46f, 44.3f), -1.25f, -2), 
                PVModel.transform.rotation);
            PV_clone.transform.parent = PV_cloneContainer.transform;
            PV_clone.transform.name = "regenPack";
            PV_clone.transform.gameObject.SetActive(true);
            PV_Is_Spawn = true;
        }
        
        
        textEventMancheEnd.gameObject.SetActive(false);
        ChronoManche.gameObject.SetActive(true);
        NewManche.gameObject.SetActive(true);
        timeRemaining = 6f;
        ChronoTime = true;
        isSpawned = false;
        StopCoroutine(Spawn());
    }

    /*
     * Spawn of monsters according to the number of rounds (trigger when the timer is at 0)
     */
    IEnumerator EnemySpawn()
    {
        int nbCroco = 0;
        while(nbCroco!= NbManche)
        {
            
            GameObject Clone = Instantiate(EnemyModel,new Vector3(Random.Range(-22.46f, 44.3f), -1.25f, -2),
                EnemyModel.transform.rotation);
            Clone.transform.parent = monsterContainer.transform;
            Clone.transform.name = "Crocodile"+(nbCroco);
            Clone.transform.gameObject.SetActive(true);
            nbCroco++;
            nbEnnemyCourant++;

            yield return new WaitForSeconds(1);
        }
        StopCoroutine(EnemySpawn());
        isSpawned = true;

    }
}
