using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image hpDisplay; 
    // Start is called before the first frame update
    

    public void UpdateBar(float healthPct)
    {
        hpDisplay.fillAmount = healthPct;
    }
}
