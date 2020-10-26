using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public float invincibleTime;

    private float Timer = 0f;

    private void Update()
    {
        Timer += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Sword" & Timer > invincibleTime)
        {
            Timer = 0f;
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        Health -= 1;
    }
}
