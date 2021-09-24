using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnManager : MonoBehaviour
{
    public GameObject[] Spawnpoints;
    public GameObject[] Cubeprefabs;
    private int index;
    private int indexcube;

    public float timeRate;

    void Start()
    {
        StartCoroutine(CreateCubes());
    }


    private IEnumerator CreateCubes()
    {
        while (true)
        {
            index = Random.Range(0, Spawnpoints.Length);
            indexcube = Random.Range(0, Cubeprefabs.Length);
            GameObject cube = Instantiate(Cubeprefabs[indexcube], Spawnpoints[index].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            cube.transform.SetParent(transform);
            yield return new WaitForSeconds(timeRate);
        }
    }

}
