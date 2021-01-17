using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAoE : MonoBehaviour {

    public bool yieldBuff;
    public bool speedBuff;

    private Seeds seeds;
    private List<Seeds> scriptList = new List<Seeds>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlantPrefab")
        {
            seeds = collision.GetComponent<Seeds>();
            if (speedBuff)
            {
                if (seeds.growingSpeedInSecs > 0.5f)
                {
                    seeds.growingSpeedInSecs -= 0.2f;
                }
            }
            if (yieldBuff)
            {
                seeds.sellingValue *= 2;
            }
            scriptList.Add(seeds);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlantPrefab")
        {
            seeds = collision.GetComponent<Seeds>();
            scriptList.Remove(seeds);
        }
    }
}
