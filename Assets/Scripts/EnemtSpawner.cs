using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtSpawner : MonoBehaviour
{
    public GameObject Dron;
    public GameObject Player;

    public float SpawnPositionRangeValue;

    public float RandomRateMin;
    public float RandomRateMax;

    float SpawnPositionRangeMin;
    float SpawnPositionRangeMax;

    float spawnRandomRate;
    float spawnDelay;

    Vector3 SpawnPoint;

    private void Awake()
    {
        SpawnPositionRangeMin = SpawnPositionRangeValue;
        SpawnPositionRangeMax = -SpawnPositionRangeValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomRate();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObject();
    }

    void RandomSpawnPoint()
    {
        float xpos = Random.Range(SpawnPositionRangeMin, SpawnPositionRangeMax);
        float zpos = Random.Range(SpawnPositionRangeMin, SpawnPositionRangeMax);
        SpawnPoint = new Vector3(xpos, 0, zpos);
    }

    void RandomRate()
    {
        spawnRandomRate = Random.Range(RandomRateMin, RandomRateMax);
    }

    void SpawnObject()
    {
        spawnDelay += Time.deltaTime;
        if(spawnDelay > spawnRandomRate)
        {
            spawnDelay = 0;
            RandomRate();
            RandomSpawnPoint();

            GameObject temp = Instantiate(Dron, Vector3.zero, Quaternion.identity);
            temp.transform.SetParent(transform);
            temp.transform.localPosition = SpawnPoint;
            temp.SetActive(true);
            temp.GetComponent<DronMove>().SetDron(Player);
        }
    }
}
