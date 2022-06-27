using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController_2D : MonoBehaviour {

  


    
    Rigidbody2D m_rigidbody;
    Animator m_Animator;
    Transform m_tran;

    private float h = 0;
    private float v = 0;

    public float MoveSpeed = 10;
   

    public SpriteRenderer[] m_SpriteGroup;

    public bool Once_Attack = false;
    private static bool IsJumping = false;

    public AudioSource epee;
    public AudioSource pointe;
    

    // Use this for initialization
    void Start () {
        m_rigidbody = this.GetComponent<Rigidbody2D>();
        m_Animator = this.transform.Find("BURLY-MAN_1_swordsman_model").GetComponent<Animator>();
        m_tran = this.transform;
        m_SpriteGroup = this.transform.Find("BURLY-MAN_1_swordsman_model").GetComponentsInChildren<SpriteRenderer>(true);
        HealthBar.FullBar();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        spriteOrder_Controller();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Once_Attack = false;

            m_Animator.SetTrigger("Attack");
            epee.Play();

            m_rigidbody.velocity = new Vector3(0, 0, 0);


        }

        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Once_Attack = false;
            pointe.Play();


            m_Animator.SetTrigger("Attack2");

            m_rigidbody.velocity = new Vector3(0, 0, 0);



        }

        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") ||
            m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            return;
        h = Input.GetAxisRaw("Horizontal");


        m_Animator.SetFloat("MoveSpeed", Mathf.Abs(h));

        Move_Fuc(h);
        
    }

    public int sortingOrder = 0;
    public int sortingOrderOrigine = 0;

    private float Update_Tic = 0;
    private float Update_Time = 0.1f;

    void spriteOrder_Controller()
    {

        Update_Tic += Time.deltaTime;

        if (Update_Tic > 0.1f)
        {
            sortingOrder = Mathf.RoundToInt(this.transform.position.y * 100);
            
            for (int i = 0; i < m_SpriteGroup.Length; i++)
            {

                m_SpriteGroup[i].sortingOrder = sortingOrderOrigine - sortingOrder;

            }

            Update_Tic = 0;
        }
        
    }
    

    // character Move Function
    void Move_Fuc(float horizontal)
    {
        
        m_tran.Translate(new Vector3(horizontal* MoveSpeed * Time.deltaTime, 0f, 0f));
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            if (B_FacingRight)
                Filp();
        }
        else if (Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            if (!B_FacingRight)
               
                Filp();
        }
    }


    // character Filp 
    bool B_Attack = false;
    bool B_FacingRight = true;
    
    void Filp()
    {
        B_FacingRight = !B_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        m_tran.localScale = theScale;
    }

}
