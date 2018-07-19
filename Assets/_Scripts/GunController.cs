using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int Mag = 20;

    public float FireRate = .1f;

    private float SetFireDelay;

    public GameObject BulletPrefab;

    public void Fire()
    {
        if (SetFireDelay == 0)
        {
            if (Mag > 0)
            {
                Mag--;
                GameObject tempBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
                tempBullet.GetComponent<Rigidbody>().velocity = transform.forward * 10;
                tempBullet.GetComponent<BulletController>().Owner = gameObject;
                Destroy(tempBullet, 5);
                Debug.Log("Mag: " + Mag);
            }
            else
            {
                Debug.Log("No more bullets!");
            }
            SetFireDelay = FireRate;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetFireDelay = Mathf.Max(0, SetFireDelay - Time.deltaTime);
    }
}
