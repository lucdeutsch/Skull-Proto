using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gate : MonoBehaviour
{
    public List<Levels> levelPool = new List<Levels>();
    List<Levels> gates = new List<Levels>();

    public int numberOfGates = 2;

    

    public SpriteRenderer gate1;
    public SpriteRenderer gate2;

    public List<Color> gatesColor = new List<Color>();

    private void Start() {
        PickGates();
    }
    void PickGates()
    {
         
        for (int i = 0; i < numberOfGates; i++)
        {
            int rnd = Random.Range(0,levelPool.Count);
            gates.Add(levelPool[rnd]);
            levelPool.Remove(levelPool[rnd]);
            DisplayGates(gates[i].levelType,i);
           
        }
        gate1.GetComponent<Teleport>().nextLevelType = gates[0];
        gate2.GetComponent<Teleport>().nextLevelType = gates[1];
        
    }

    void DisplayGates(Levels.LevelType levelType, int index)
    {
        switch (index)
        {
            case 0:
                switch (levelType)
                {
                case Levels.LevelType.Chest:
                gate1.color = gatesColor[0];
                break;
                
                case Levels.LevelType.Skul:
                gate1.color = gatesColor[1];
                break;
                
                case Levels.LevelType.Shop:
                gate1.color = gatesColor[2];
                break;
                
                case Levels.LevelType.regular:
                gate1.color = gatesColor[3];
                break;
                
                default:
                break;
                }
                    break;
            case 1:
                switch (levelType)
                {
                case Levels.LevelType.Chest:
                gate2.color = gatesColor[0];
                break;
                
                case Levels.LevelType.Skul:
                gate2.color = gatesColor[1];
                break;
                
                case Levels.LevelType.Shop:
                gate2.color = gatesColor[2];
                break;
                
                case Levels.LevelType.regular:
                gate2.color = gatesColor[3];
                break;
                
                default:
                break;
                }
                break;
            default:
            break;
        }
        
        
    }
}
