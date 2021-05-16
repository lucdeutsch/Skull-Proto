using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    public GameObject swordUI;
    public GameObject bowUI;
    public GameObject staffUI;

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.currentSkul)
        {
            case GameManager.Skulls.Sword:
                swordUI.SetActive(true);
                bowUI.SetActive(false);
                staffUI.SetActive(false);
                break;
            case GameManager.Skulls.Bow:
                swordUI.SetActive(false);
                bowUI.SetActive(true);
                staffUI.SetActive(false);
                break;
            case GameManager.Skulls.Staff:
                swordUI.SetActive(false);
                bowUI.SetActive(false);
                staffUI.SetActive(true);
                break;
            default:
                break;
        }

    }
}
