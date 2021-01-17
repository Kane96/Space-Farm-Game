using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantColliderPlacement : MonoBehaviour {

    private Seeds parent;

    void Start()
    {
        parent = transform.parent.gameObject.GetComponent<Seeds>();
    }

    public void OnMouseDown()
    {
        if (SeedSelect.currentObjectSelected == null)
        {
            parent.replant();
        }
    }

    public void digUp()
    {
        parent.digUp();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grid")
        {
            GrassBlockPlanting script = collision.gameObject.GetComponent<GrassBlockPlanting>();
            script.gridEmpty = false;
            parent.grassList.Add(script);
        }
    }
}
