using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bulletHit;
    public GameObject enemyHit;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(enemyHit, transform.position, transform.rotation);
        }
        Instantiate(bulletHit, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
