using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public bool hit;
    public float timeBeforeDestruction;
    private void OnEnable() 
    {
        StartCoroutine(AutoDestruct());
    }

    IEnumerator AutoDestruct()
    {
        yield return new WaitForSeconds(timeBeforeDestruction);
        Destroy(this.gameObject);
    }
}
