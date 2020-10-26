using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{

    public GameObject explosionPrefab;
    public float explosionRadius;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            Collider[] allColliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach(var item in allColliders)
            {
                if (item.attachedRigidbody)
                {
                    if (item.GetComponent<BodyPartScript>())
                    {
                        item.GetComponent<BodyPartScript>().thisEnemy.TakeDamage();
                    }

                    if (item.attachedRigidbody.GetComponent<PlayerHealth>())
                    {
                        item.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage();
                    }
                    Vector3 direction = (item.transform.position - transform.position).normalized;
                    item.attachedRigidbody.AddForce(direction * 3000f);
                }
            }

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
