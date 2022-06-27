using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallScript : MonoBehaviour
{
    private Transform m_transform;

    private CharacterController_2D CharacterMovement;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        CharacterMovement = GetComponent<CharacterController_2D>();

    }

    // Update is called once per frame
    void Update()
    {
        FallDead();
        
    }
    
    

    public void FallDead()
    {
        if (m_transform.position.y <= -3)
        {
            CharacterMovement.enabled = false;
            m_transform.position.Set(m_transform.position.x,m_transform.position.y,3);
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScreen");
            
            
            
        }
    }
}
