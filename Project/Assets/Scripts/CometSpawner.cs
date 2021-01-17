using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour {

    public GameObject comet1;
    public GameObject comet2;
    [Range(0, 100)]
    public float chanceOfCometPerSec;
    public float minAngle;
    public float maxAngle;
    public float cooldown;

    private GameObject spawnedComet;
    private float random;
    private float timer;
    private float cooldownTimer;
    private float spawnRatePrivate;

	void Start () {
        spawnRatePrivate = chanceOfCometPerSec/10;
	}
	
	void Update () {
        timer += Time.deltaTime;
        cooldownTimer += Time.deltaTime;
        //does 10 rolls a sec, hence why the variable chanceOfCometPerSec is divided by 10
        if (timer > 0.1 && cooldownTimer > cooldown)
        {
            random = Random.Range(0f, 100f);
            if (random < spawnRatePrivate)
            {
                if (Random.Range(0,2) == 0)
                {
                    if (comet1 != null)
                    {
                        spawnedComet = Instantiate(comet1, transform.position, transform.rotation) as GameObject;
                        //spawnedComet.transform.parent = gameObject.transform;
                    }
                }
                else
                {
                    spawnedComet = Instantiate(comet2, transform.position, transform.rotation) as GameObject;
                    //spawnedComet.transform.parent = gameObject.transform;
                }
                transform.rotation = (Quaternion.Euler(0, 0, Random.Range(minAngle, maxAngle)));
                cooldownTimer = 0;
            }
            timer = 0;
        }
	}

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
