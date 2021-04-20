using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    float dir;

    [Header("Sword")]
    
    public float range = 2;
    RaycastHit2D hit2D;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dir = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("rr");
            BasicAttack(GameManager.Instance.currentSkul);
        }
    }

    void BasicAttack(GameManager.Skulls current)
    {
        switch (current)
        {
            case GameManager.Skulls.Sword:
                SwordBasic();
                break;
            case GameManager.Skulls.Bow:
                BowBasic();
                break;
            case GameManager.Skulls.Staff:
                StaffBasic();
                break;
            default:
                break;
        }
    }

    void SwordBasic()
    {
        if (dir>=0)
        {
            Debug.Log("right");
            Physics2D.Raycast(transform.position,transform.right,range);
            
        }
        else
        {
            Debug.Log("left");
            Physics2D.Raycast(transform.position,-transform.right,range);
            
        }
            
        
    }

    void BowBasic()
    {

    }

    void StaffBasic()
    {

    }

    void PrimarySkill()
    {

    }

    void SecondarySkill()
    {

    }
}
