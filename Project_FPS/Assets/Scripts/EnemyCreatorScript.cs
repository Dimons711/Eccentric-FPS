using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatorScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float creationPeriod;
    private float Timer = 0f;
    public float offsetValue;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > creationPeriod)
        {
            Timer = 0;
            Vector3 randomOffset = new Vector3(Random.Range(-offsetValue, offsetValue), 0f, Random.Range(-offsetValue, offsetValue));
            Instantiate(enemyPrefab, transform.position + randomOffset , transform.rotation);
        }
    }
}
