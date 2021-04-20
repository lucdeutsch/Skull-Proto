using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [HideInInspector]
    public Levels nextLevelType;
    bool canTeleport = false;
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            canTeleport = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            canTeleport = false;
        }
    }







    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F) && canTeleport)
        {
            ChangeScene(nextLevelType.index);
        }
    }

    void ChangeScene(int index)
    {
    
        GameManager.Instance.levelsCompleted +=1;
        DontDestroyOnLoad(GameManager.Instance.gameObject);
        SceneManager.LoadScene(nextLevelType.levelType.ToString()+index.ToString());
        
    }

}
