using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public ParticleSystem.MinMaxCurve spawnIntervalRange = new ParticleSystem.MinMaxCurve(1f, 3f);
    public GameObject[] cubePrefabs;
    private int cubeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
    }
    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnIntervalRange.Evaluate(Random.Range(0f, 1f)));
            Instantiate(cubePrefabs[Random.Range(0, 2)], new Vector3(0, cubeCount, 0), Quaternion.identity);
            cubeCount++;
        }
    }
    public void SpawnCube()
    {
        StartCoroutine(SpawnLoop());
    }
    public void StopSpawn()
    {
        StopAllCoroutines();
    }
    public void Reset()
    {
        cubeCount = 0;
        var activeCubes = FindObjectsOfType<CubeController>();
        for (int i = activeCubes.Length - 1; i > -1; i--)
            activeCubes[i].Dispose();//clean all cubes
    }
}
