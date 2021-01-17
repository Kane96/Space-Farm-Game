using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour {

    public GameObject controller;
    public bool upOrRight;

    private GameObject grassBlock;
    private Color startColor;
    private Color previewColor;
    private SpriteRenderer sprite;
    private GameObject newBlock;

	void Start () {
        startColor = Color.white;
        previewColor = Color.white;
        startColor.a = 0f;
        previewColor.a = 0.5f;
        sprite = gameObject.GetComponent<SpriteRenderer>();

        sprite.color = startColor;
        if (upOrRight)
        {
            sprite.sortingOrder = gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder - 10;
        }
        else
        {
            sprite.sortingOrder = gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 10;
        }
        grassBlock = controller.GetComponent<MasterController>().originalGrassPrefab;
	}

    private void OnMouseOver()
    {
        if (SeedSelect.currentObjectSelected != null)
        {
            if (SeedSelect.currentObjectSelected.name == "GrassBlockSelect")
            {
                sprite.color = previewColor;
            }
        }
        else
        {
            sprite.color = startColor;
        }
    }

    private void OnMouseExit()
    {
        sprite.color = startColor;
    }

    private void OnMouseDown()
    {
        if (SeedSelect.currentObjectSelected != null)
        {
            if (SeedSelect.currentObjectSelected.name == "GrassBlockSelect")
            {
                newBlock = Instantiate(grassBlock, this.transform.position, Quaternion.identity) as GameObject;
                newBlock.transform.parent = gameObject.transform.parent.transform.parent;
                GrassBlock.isBought = true;
                if (upOrRight)
                {
                    newBlock.GetComponent<SpriteRenderer>().sortingOrder = gameObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder - 10;
                }
                else
                {
                    newBlock.GetComponent<SpriteRenderer>().sortingOrder = gameObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder + 10;
                }

                if (!Input.GetKey(KeyCode.LeftControl))
                {
                    SeedSelect.currentObjectSelected = null;
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
