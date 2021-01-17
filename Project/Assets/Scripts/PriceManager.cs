using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceManager : MonoBehaviour {

    public int basePrice;
    public int priceIncrease;
    public int currentPrice;

    private Text priceText;

	void Start ()
    {
        priceText = GetComponent<Text>();
        currentPrice = basePrice;
        updateText();
	}

    public void increasePrice()
    {
        currentPrice += priceIncrease;
        updateText();
    }

    public void decreasePrice()
    {
        currentPrice -= priceIncrease;
        updateText();
    }

    public void updateText()
    {
        priceText.text = currentPrice.ToString();
    }
}
