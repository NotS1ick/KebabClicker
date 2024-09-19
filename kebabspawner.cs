using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KebabSpawner : MonoBehaviour
{
    public GameObject kebabPrefab;
    public float spawnRate = 2f;
    private float timer = 0f;

    void Start() {
        SpawnKebab();
    }

    void SpawnKebab()
    {
        float randomRotation = Random.Range(0f, 360f);
        Vector3 spawnPosition = transform.position;
        
        GameObject spawnedKebab = Instantiate(kebabPrefab, spawnPosition, Quaternion.Euler(0f, 0f, randomRotation));
        
        Rigidbody2D rb = spawnedKebab.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float randomTorque = Random.Range(-10f, 10f);
            rb.AddTorque(randomTorque);
        }
    }

    void Update()
    {
        if (timer < spawnRate) 
        {
            timer += Time.deltaTime;
        } 
        else 
        {
            SpawnKebab();
            timer = 0f;
        }
    }
}