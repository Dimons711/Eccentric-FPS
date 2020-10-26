using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public int Bullets;
    public int bulletSpeed;
    public float shotDelay;

    public GameObject BulletPrefab;
    public GameObject Spawn;
    public GameObject Flash;

    private float Timer;
    private AudioSource shotSound;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
        shotSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Input.GetMouseButton(0) & Bullets > 0 & Timer > shotDelay)
        {
            Bullets -= 1;
            Timer = 0;

            shotSound.pitch = Random.Range(0.8f, 1.2f);
            shotSound.Play();

            GameObject newBullet = Instantiate(BulletPrefab, Spawn.transform.position, Spawn.transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = Spawn.transform.forward * bulletSpeed;
            Flash.SetActive(true);
            Invoke("HideFlash", 0.05f);
        }
    }

    void HideFlash()
    {
        Flash.SetActive(false);
    }
}
