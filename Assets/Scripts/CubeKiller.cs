using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeKiller : MonoBehaviour
{
    /// <summary>
    /// Destroy(other.gameObject); 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.LoseMultiplier();
        Destroy(other.gameObject); 
    }


}
