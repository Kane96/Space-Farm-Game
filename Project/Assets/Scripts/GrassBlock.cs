using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBlock : MonoBehaviour {

    public static bool isBought = false;
    public static bool isFirstBlock = true;
    private GameObject priceGameObject;
    private PriceManager priceManager;

    void Start() {
        priceGameObject = GameObject.Find("ButtonLandPrice");
        priceManager = priceGameObject.GetComponent<PriceManager>();

        if (isBought)
        {
            Credits.decreaseCredits(priceManager.currentPrice);
            isBought = false;
        }
        if (isFirstBlock)
        {
            isFirstBlock = false;
        }
        else
        {
            priceManager.increasePrice();
        }

		if (gameObject.transform.position.x > CameraMovement.maxXValue)
        {
            CameraMovement.maxXValue = gameObject.transform.position.x;
        }
        if (gameObject.transform.position.x < CameraMovement.minXValue)
        {
            CameraMovement.minXValue = gameObject.transform.position.x;
        }
        if (gameObject.transform.position.y > CameraMovement.maxYValue)
        {
            CameraMovement.maxYValue = gameObject.transform.position.y;
        }
        if (gameObject.transform.position.y < CameraMovement.minYValue)
        {
            CameraMovement.minYValue = gameObject.transform.position.y;
        }
    }
}
