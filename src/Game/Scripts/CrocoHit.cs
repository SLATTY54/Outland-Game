using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class CrocoHit : MonoBehaviour
{
    public int sortingOrder = 0;
    public int sortingOrderOrigine = 0;
    public SpriteRenderer[] m_SpriteGroup;

    public static bool IsAttack = false;
    

     public Animator m_Animator;

     public Animator perso; 

     public Transform player;

     public bool temp = false;

     public EnemyIA IA;

     private bool IsDead;
    // Use this for initialization
    void Start () {
       
        m_SpriteGroup = this.transform.GetComponentsInChildren<SpriteRenderer>(true);
        InvokeRepeating("Attack",0,2);

        spriteOrder_Controller();
        IsDead = false;


    }

    


    void spriteOrder_Controller()
    {
        sortingOrder = Mathf.RoundToInt(this.transform.position.y * 100);
        //Debug.Log("y::" + this.transform.position.y);
        //  Debug.Log("sortingOrder::" + sortingOrder);
        for (int i = 0; i < m_SpriteGroup.Length; i++)
        {

            m_SpriteGroup[i].sortingOrder = sortingOrderOrigine - sortingOrder;

        }

    }

    public void  Sword_Hitted()
    {
        m_Animator.Play("dead");
        IsDead = true;
        IA.enabled = false;
        StartCoroutine(Pause());
    }
    
    


    public void Attack()
    {
        
        if (temp && !IsDead)
        {
            m_Animator.Play("attack1");
            HealthBar.PV_c -= 25;
            perso.Play("Hit");
            
            
            
            
        }
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
            temp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            temp = false;
        }
    }


    IEnumerator Pause()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        Destroy(transform.parent.gameObject);
        MancheScript.nbEnnemyCourant -= 1;
    }
    
    

  

}

