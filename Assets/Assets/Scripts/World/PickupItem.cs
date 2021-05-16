using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    bool canPickUp = false;
    public GameManager.Skulls skullType;
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            canPickUp = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            canPickUp = false;
        }
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F) && canPickUp)
        {
            GameManager.Instance.currentSkul = skullType;
            Destroy(gameObject);
        }
    }
}
