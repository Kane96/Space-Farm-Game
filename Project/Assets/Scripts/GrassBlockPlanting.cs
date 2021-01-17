using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBlockPlanting : MonoBehaviour {

    public int sortingLayer;
    public bool gridEmpty = true;
    public static int numberOfOtherCollisions = 0;

    private Seeds seedScript;
    private Vector3 mousePos;
    private GameObject plant;
    private PolygonCollider2D poly;

	void Start () {

        //Instantiating the placement indicator, making it invisible at first
        sortingLayer += gameObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder;
        poly = gameObject.GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (gridEmpty == false)
        {
            poly.enabled = false;
        }
        else
        {
            poly.enabled = true;
        }
    }

    //private void Update()
    //{
    //    //2x2 debug
    //    if (isBeingChecked == false)
    //    {
    //        placeIndicator.GetComponent<SpriteRenderer>().color = placementIndicatorStart;
    //    }
    //    else
    //    {
    //        //debug, change for 1x1 
    //        checkAvailabilityLargePlant(numberOfOtherCollisions);
    //    }
    //    if (SeedSelect.objectIsSelected)
    //    {
    //        poly.enabled = true;
    //    }
    //    else
    //    {
    //        poly.enabled = false;
    //    }
    //}


    //private void OnMouseDown()
    //{
    //    if (SeedSelect.objectIsSelected)
    //    {
    //        if (gridEmpty)
    //        {
    //             //Instantiate the plant at the current grid
    //            plant = Instantiate(SeedSelect.currentObjectSelected, transform.position, Quaternion.identity) as GameObject;
    //            plant.GetComponent<SpriteRenderer>().sortingOrder = sortingLayer;
    //            plant.transform.parent = gameObject.transform;
    //            seedScript = plant.GetComponent<Seeds>();
    //            Credits.decreaseCredits(seedScript.buyingValue);
    //        }
    //        placeIndicator.GetComponent<SpriteRenderer>().color = placementIndicatorStart;
    //        SeedSelect.objectIsSelected = false;
    //        gridEmpty = false;
    //    }
    //}

    //void OnMouseOver()
    //{
    //    //Show availability of plot for 1x1
    //    //Uncomment for normal functionality
    //    //checkAvailability();
    //}

    //private void OnMouseExit()
    //{
    //    placeIndicator.GetComponent<SpriteRenderer>().color = placementIndicatorStart;
    //}

    //public void checkAvailability()
    //{
    //    if (SeedSelect.objectIsSelected && gridEmpty == false)
    //    {
    //        placeIndicator.GetComponent<SpriteRenderer>().color = cantPlace;
    //    }
    //    else if (SeedSelect.objectIsSelected && gridEmpty == true)
    //    {
    //        placeIndicator.GetComponent<SpriteRenderer>().color = canPlace;
    //    }
    //}

    //for testing 2x2 checking

    //public void checkAvailabilityLargePlant(int currentSpaces)
    //{
    //    if (gridEmpty == false || currentSpaces != 4)
    //    {
    //        placeIndicator.GetComponent<SpriteRenderer>().color = cantPlace;
    //        ColliderPlanting.allSquaresEmpty = false;
    //    }
    //    else if (gridEmpty == true && currentSpaces == 4)
    //    {
    //        placeIndicator.GetComponent<SpriteRenderer>().color = canPlace;
    //        ColliderPlanting.allSquaresEmpty = true;
    //    }
    //}
}


