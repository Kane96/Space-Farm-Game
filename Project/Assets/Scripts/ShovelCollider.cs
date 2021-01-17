using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelCollider : MonoBehaviour {

    private Vector3 mousePos;
    private GameObject currentCollision;

	void Update () {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if (((Mathf.Round(mousePos.y * 4) / 4) % 0.5) == 0 || ((Mathf.Round(mousePos.y * 4) / 4) == 0))
        {
            transform.position = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y * 4) / 4, 0);
        }
        else
        {
            transform.position = new Vector3(Mathf.Ceil(mousePos.x) - 0.5f, Mathf.Round(mousePos.y * 4) / 4, 0);
        }
        if (!SeedSelect.shovelCheck())
        {
            Destroy(gameObject);   
        }
        if (Input.GetMouseButton(0) && currentCollision != null)
        {
            currentCollision.GetComponent<Seeds>().digUp();
            if (!Input.GetKey(KeyCode.LeftControl))
            {
                Destroy(gameObject);
                SeedSelect.currentObjectSelected = null;
            }
        }
        if (Input.GetMouseButton(1))
        {
                SeedSelect.currentObjectSelected = null;
                Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlantPrefab")
        {
            currentCollision = collision.gameObject;
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        currentCollision = null;
        if (collision.tag == "PlantPrefab")
        {
            collision.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
