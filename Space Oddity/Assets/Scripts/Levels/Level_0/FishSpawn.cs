using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;


public class FishSpawn : MonoBehaviour
{
    public GameObject[] fish;
    [SerializeField] private GameObject PanelVictory;

    SerialPort puertoExtras;

    public float timeSpawn = 1;
    public float repeatSpawn = 3;


    public Transform XRangeLeft;
    public Transform XRangeRight;

    public Transform YRangeUp;
    public Transform YRangeDown;

    public float difficultyTime;

    void Start()
    {
        StartCoroutine("Difficulty");
        PanelVictory.SetActive(false);

        puertoExtras = FindObjectOfType<PlayerMov>().puerto2;

        puertoExtras.ReadTimeout = 40;
        if (puertoExtras.IsOpen) { }
        else
        {
            puertoExtras.Open();
        }
    }

    private void Update()
    {
        difficultyTime += Time.deltaTime;

        if (difficultyTime > 5 && difficultyTime < 10)
            repeatSpawn = 1;

        if (difficultyTime > 10 && difficultyTime < 15)
            repeatSpawn = 0.50f;

        if (difficultyTime > 15 && difficultyTime < 20)
            repeatSpawn = 0.30f;

        if (difficultyTime >= 25)
        {
            PanelVictory.SetActive(true);
            if (puertoExtras.IsOpen)
            {
                puertoExtras.Write("victory");
            }
        }
    }

    IEnumerator Difficulty()
    {
        yield return new WaitForSeconds(repeatSpawn);
        if (difficultyTime < 20)
        {
            SpawnEnemies();

            StartCoroutine("Difficulty");
        }
    }

    public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);

        spawnPosition = new Vector3(Random.Range(XRangeLeft.position.x, XRangeRight.position.x), Random.Range(YRangeDown.position.y, YRangeUp.position.y), 0);

        GameObject fishes = Instantiate(fish[Random.Range(0, fish.Length)], spawnPosition, gameObject.transform.rotation);
    }
}