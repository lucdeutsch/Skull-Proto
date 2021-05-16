using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    bool canPickUp = false;
    public GameManager.Skulls skullType;
    public Sprite swordSprite;
    public Sprite bowSprite;
    public Sprite staffSprite;


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
            GameObject newItem = Instantiate(this.gameObject, transform.position, Quaternion.identity);
            newItem.GetComponent<PickupItem>().skullType = GameManager.Instance.currentSkul;
            switch (newItem.GetComponent<PickupItem>().skullType)
            {
                case GameManager.Skulls.Sword:
                    newItem.GetComponent<SpriteRenderer>().sprite = swordSprite;
                    break;
                case GameManager.Skulls.Bow:
                    newItem.GetComponent<SpriteRenderer>().sprite = bowSprite;
                    break;
                case GameManager.Skulls.Staff:
                    newItem.GetComponent<SpriteRenderer>().sprite = staffSprite;
                    break;
                default:
                    break;
            }
            
            GameManager.Instance.currentSkul = skullType;
            Destroy(gameObject);
        }
    }
}
