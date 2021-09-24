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
        CubePhysics cubeP = other.GetComponent<CubePhysics>();
        Debug.Log(other.name);
        if (cubeP != null && cubeP.failed && (other.name == "GunCube(Clone)" || other.name == "SwordCube(Clone)" ))
        {
            cubeP.failed = false;
            ScoreManager.instance.LoseMultiplier();

            //Play error sound
            AudioManager.instance.errorSound.gameObject.transform.position = other.transform.position;
            AudioManager.instance.errorSound.Play();

            Destroy(other.gameObject);
        }
    }

}
