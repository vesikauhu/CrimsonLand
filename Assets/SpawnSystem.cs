using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    public GameObject spawnSmokePrefab;
    public GameObject enemyPrefab;
    public SpawnSpeed spawnSpeed = SpawnSpeed.VerySlow;
    public bool Static;
    private Transform[] _spawnLocations = new Transform[20];
    private float spawnInterval = 300f;
    private float spawnTimer = 0f;
    public enum SpawnSpeed
    {
        VerySlow,
        Slow,
        Normal,
        Fast,
        VeryFast
    }

    void Start()
    {

        _spawnLocations = GameObject.Find("SpawnLocations").GetComponentsInChildren<Transform>();
        _spawnLocations[0] = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (!Static)
            spawnInterval -= Time.deltaTime;

        if (spawnInterval < 60f)
            spawnSpeed = SpawnSpeed.VeryFast;
        else if (spawnInterval < 120f)
            spawnSpeed = SpawnSpeed.Fast;
        else if (spawnInterval < 180f)
            spawnSpeed = SpawnSpeed.Normal;
        else if (spawnInterval < 240f)
            spawnSpeed = SpawnSpeed.Slow;

        SpawnEnemies();

    }

    void SpawnEnemies()
    {
        switch (spawnSpeed)
        {
            case SpawnSpeed.VerySlow:
                if (spawnTimer < 10f)
                {
                    spawnTimer += Time.deltaTime;
                }
                else
                {
                    spawnTimer = 0f;
                    StartCoroutine(InstantiateEnemy(10));
                }
                break;
            case SpawnSpeed.Slow:
                if (spawnTimer < 8f)
                {
                    spawnTimer += Time.deltaTime;
                }
                else
                {
                    spawnTimer = 0f;
                    StartCoroutine(InstantiateEnemy(20));

                }
                break;
            case SpawnSpeed.Normal:
                if (spawnTimer < 6f)
                {
                    spawnTimer += Time.deltaTime;
                }
                else
                {
                    spawnTimer = 0f;
                    StartCoroutine(InstantiateEnemy(20));

                }
                break;
            case SpawnSpeed.Fast:
                if (spawnTimer < 4f)
                {
                    spawnTimer += Time.deltaTime;
                }
                else
                {
                    spawnTimer = 0f;
                    StartCoroutine(InstantiateEnemy(20));
                }
                break;
            case SpawnSpeed.VeryFast:
                if (spawnTimer < 2f)
                {
                    spawnTimer += Time.deltaTime;
                }
                else
                {
                    spawnTimer = 0f;
                    StartCoroutine(InstantiateEnemy(20));
                }
                break;
        }


    }

    IEnumerator InstantiateEnemy(int locations)
    {
        int[] locationList = new int[locations];

        for (int i = 0; i < locations; i++)
        {
            int rnd = Random.Range(1, 20);
            locationList[i] = rnd;
        }

        foreach (int t in locationList)
        {
            GameObject smoke = Instantiate(spawnSmokePrefab, _spawnLocations[t].position, Quaternion.identity);
            Destroy(smoke, 5f);
        }

        yield return new WaitForSeconds(3.5f);

        foreach (int t in locationList)
        {
            GameObject enemy = Instantiate(enemyPrefab, _spawnLocations[t].position, Quaternion.identity);
            enemy.transform.LookAt(GameObject.Find("Player").transform);
        }

    }
}