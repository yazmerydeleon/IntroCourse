using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public int Mag = 20;

    public float FireRate = 0.1f;

    private float SetFiredDelay = 0;

    public GameObject BulletPrefab;

	// Use this for initialization
	void Start () {
		
	}

    public void Fire()
    {
        
            if (Mag > 0 && SetFiredDelay <= 0)
            {
            //Debug.Log("Fire!!");
            GameObject TempBullet =  Instantiate( BulletPrefab, transform.position, transform.rotation);
            TempBullet.GetComponent<Rigidbody>().velocity = transform.forward * 100;

                SetFiredDelay = FireRate;
                Mag --;
                Debug.Log(Mag);
            }           
        
        
    }

    // Update is called once per frame
    void Update () {
        SetFiredDelay -= Time.deltaTime;
		
	}
}
