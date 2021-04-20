using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            GameManager[] managers = FindObjectsOfType(typeof(GameManager)) as GameManager[];
            if (managers.Length == 0)
            {
                Debug.LogWarning("GameManager not present on the scene. Creating a new one.");
                GameManager manager = new GameObject("Game Manager").AddComponent<GameManager>();
                _instance = manager;
                return _instance;
            }
            else
            {
                return managers[0];
            }
        }
        set
        {
            if (_instance == null)
                _instance = value;
            else
            {
                Debug.LogError("You can only use one GameManager. Destroying the new one attached to the GameObject " + value.gameObject.name);
                Destroy(value);
            }
        }
    }

    public enum Skulls
    {
        Sword,
        Bow,
        Staff
    }

    public Skulls currentSkul;
    public int playerLife;
    public int bones;
    public int gold;
    public int levelsCompleted;
}
