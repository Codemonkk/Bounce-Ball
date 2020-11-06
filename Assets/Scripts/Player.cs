using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject WallBounceEffectObj;
    public GameObject DeadEffectObj;

    public CameraShake cameraShake;
    public GameObject GameOverPanel;
    
    Rigidbody2D rb;

    int JumpX = 7;
    int JumpY = 15;
    

    bool isDead = false;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        GameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(JumpX, JumpY);
            }
            else
            {
                rb.velocity = new Vector2(-JumpX, JumpY);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "WallPoint")
        {
            GameObject effectObj = Instantiate(WallBounceEffectObj, other.contacts[0].point, Quaternion.identity);
            Destroy(effectObj, 0.5f);
            GameManager.instance.IncreaseScore();

            //Debug.Log(score);
        }
        else if(other.gameObject.tag == "Wall")
        {
            GameObject effectObj = Instantiate(WallBounceEffectObj, other.contacts[0].point, Quaternion.identity);
            Destroy(effectObj, 0.5f);
        }
        if (other.gameObject.tag == "Triangle" && isDead == false)
        {
            isDead = true;
            GameObject effectObj = Instantiate(DeadEffectObj, other.contacts[0].point, Quaternion.identity);
            Destroy(effectObj, 0.5f);
            
            //StartCoroutine(cameraShake.Shake(0.2f, 0.2f));

            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            gameObject.SetActive(false);
            GameOverPanel.SetActive(true);
            

        }
     }
    
    
}
