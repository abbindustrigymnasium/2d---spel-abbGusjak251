using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spawnScript : MonoBehaviour
{   
    public GameObject prefab;
    private GameObject UIManager;
    public int wave = 0;
    private const int instances = 2;
    private const float spawnDelay = 3f;
    private int timer  = 1000;
    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.Find("Canvas");
    }

    IEnumerator SpawnCoroutine() {
        timer = 2000;
        wave++;
        UIManager.GetComponent<UIScript>().wave = wave;
        for(int i=0; i<wave*instances; i++) {
            yield return new WaitForSeconds(spawnDelay);
            GameObject instance = Instantiate(prefab);
            float z = transform.position.z + Random.Range(-8, 8);
            instance.transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }
        StopCoroutine("SpawnCoroutine");
    }

    void spawnEnemy() {
        StartCoroutine("SpawnCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0) {
            timer--;
        } else {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length == 0) {
                spawnEnemy();
            }
        }
    }
}
