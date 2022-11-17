using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    [SerializeField]GameObject[] CandyGameObjects;
    GameObject Player;

    [SerializeField] float spawnTime;

    void Start()
    {
        StartCoroutine(SpawnerBad());
    Player = GameObject.FindGameObjectWithTag("PlayerNew");
    }




    IEnumerator SpawnerBad()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(CandyGameObjects[Random.Range(0,3)],new Vector3(Player.transform.position.x + Random.Range(-10, 10), 0.64f, Player.transform.position.z + Random.Range(-5, 10)), Quaternion.identity);

        }



    }
}
