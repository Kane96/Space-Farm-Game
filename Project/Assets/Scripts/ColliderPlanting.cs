using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPlanting : MonoBehaviour {

    public static bool shouldBeDead = false;
    private int plantTilesTotal;
    private Vector3 mousePos;
    private List<GrassBlockPlanting> scriptList = new List<GrassBlockPlanting>();
    private GrassBlockPlanting script;
    private SpriteRenderer sprite;
    private Color cantPlace;
    private Color canPlace;
    private GameObject plant;
    private PolygonCollider2D poly;
    private BoxCollider2D box;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = SeedSelect.currentObjectSelected.GetComponent<SpriteRenderer>().sprite;
        cantPlace = Color.red;
        cantPlace.a = 0.5f;
        canPlace = Color.green;
        canPlace.a = 0.5f;
        plantTilesTotal = SeedSelect.currentObjectSelected.GetComponent<Seeds>().totalTileSize;
    }

    void Update () {
        if (shouldBeDead)
        {
            die();
        }
        if (SeedSelect.currentObjectSelected == null)
        {
            Destroy(gameObject);
        }
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if (plantTilesTotal > 1)
        {
            if (((Mathf.Round(mousePos.y * 4) / 4) % 0.5) == 0 || ((Mathf.Round(mousePos.y * 4) / 4) == 0))
            {
                transform.position = new Vector3(Mathf.Ceil(mousePos.x) - 0.5f, Mathf.Round(mousePos.y * 4) / 4, 0);
            }
            else
            {
                transform.position = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y * 4) / 4, 0);
            }
        }
        else
        {
            poly = gameObject.GetComponent<PolygonCollider2D>();
            box = gameObject.GetComponent<BoxCollider2D>();
            box.enabled = true;
            poly.enabled = false;
            //transform.localScale = new Vector3(0.5f, 0.5f, 0);
            if (((Mathf.Round(mousePos.y * 4) / 4) % 0.5) == 0 || ((Mathf.Round(mousePos.y * 4) / 4) == 0))
            {
                transform.position = new Vector3(Mathf.Round(mousePos.x) , Mathf.Round(mousePos.y * 4) / 4, 0);
            }
            else
            {
                transform.position = new Vector3(Mathf.Ceil(mousePos.x) - 0.5f, Mathf.Round(mousePos.y * 4) / 4, 0);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (scriptList.Count == plantTilesTotal)
            {
                plant = Instantiate(SeedSelect.currentObjectSelected, transform.position, Quaternion.identity) as GameObject;
                plant.GetComponent<Seeds>().sortingLayer = Mathf.RoundToInt(mousePos.y * -100);
                //foreach (GrassBlockPlanting grassScript in scriptList)
                //{
                //    plant.GetComponent<Seeds>().grassList.Add(grassScript);
                //}
                //foreach (GrassBlockPlanting grassScript in scriptList)
                //{
                //    grassScript.gridEmpty = false;
                //}
                if (!Input.GetKey(KeyCode.LeftControl))
                {
                    die();
                }
            }
        }

        if (scriptList.Count < plantTilesTotal)
        {
            sprite.color = cantPlace;
        }
        else
        {
            sprite.color = canPlace;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grid")
        {
            script = collision.gameObject.GetComponent<GrassBlockPlanting>();
            if (script.gridEmpty)
            {
                scriptList.Add(script);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grid")
        {
            script = collision.gameObject.GetComponent<GrassBlockPlanting>();
            scriptList.Remove(script);
        }
    }

    private void die()
    {
        SeedSelect.currentObjectSelected = null;
        Destroy(gameObject);
    }
}
