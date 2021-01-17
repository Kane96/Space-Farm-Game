using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedSelect : MonoBehaviour
{

    public GameObject buttonSelect;
    public Image buttonIcon;
    public bool shovelSelector = false;
    public GameObject plantPlacement;
    public static GameObject currentObjectSelected;
    public static GameObject colliderPlacement;
    public static GameObject shovelPlacement;
    public string buttonPriceObjectName;
    public GameObject priceGameObject;
    public PriceManager priceManager;
    public static Text infoText;

    private Color deselectedColour = Color.grey;
    private Color deselectedTooPoor = Color.red;
    private Seeds seedScript;
    private Image iconImage;
    private GameObject newPlant;

    public void Start()
    {
        infoText = GameObject.Find("ButtonInfo").GetComponent<Text>();

        deselectedTooPoor.a = 0.5f;
        deselectedColour.a = 0.5f;
        buttonIcon.GetComponent<Image>().color = deselectedColour;
        iconImage = buttonIcon.GetComponent<Image>();

        if (!shovelSelector)
        {
            priceGameObject = GameObject.Find(buttonPriceObjectName);
            priceManager = priceGameObject.GetComponent<PriceManager>();
        }
    }

    private void Update()
    {
        if (currentObjectSelected == buttonSelect)
        {
            iconImage.color = Color.white;

            if (!shovelSelector)
            {
                if (priceManager.currentPrice > Credits.getCredits())
                {
                    SeedSelect.currentObjectSelected = null;
                    Destroy(colliderPlacement);
                }
            }
        } 
        else
        {
            if (!shovelSelector)
            {
                if (priceManager.currentPrice > Credits.getCredits())
                {
                    iconImage.color = deselectedTooPoor;
                }
                else
                {
                    iconImage.color = deselectedColour;
                }
            }
            else
            {
                iconImage.color = deselectedColour;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            SeedSelect.currentObjectSelected = null;
            Destroy(colliderPlacement);
        }
    }

    public void selectObject()
    {
        if (shovelSelector)
        {
            Instantiate(plantPlacement, Input.mousePosition, Quaternion.identity);
            Destroy(colliderPlacement);
            currentObjectSelected = buttonSelect;
            //if (currentObjectSelected == buttonSelect)
            //{
            //    objectIsSelected = !objectIsSelected;
            //    objectIsSelected = true;
            //}
        }
        else if (Credits.getCredits() >= priceManager.currentPrice)
        {
            Destroy(colliderPlacement);
            Destroy(shovelPlacement);
            currentObjectSelected = buttonSelect;
            if (currentObjectSelected == buttonSelect)
            {
                if (buttonSelect.name != "GrassBlockSelect")
                {
                    colliderPlacement = Instantiate(plantPlacement, Input.mousePosition, Quaternion.identity) as GameObject;
                }
            }
        }
    }

    public static bool shovelCheck()
    {
        if (currentObjectSelected != null)
        {
            if (currentObjectSelected.name == "ShovelCollider")
            {
                return true;
            }
        }
        return false;
    }

    public void changeText(string newText)
    {
        infoText.text = newText;
    }

    public void resetText()
    {
        infoText.text = "";
    }
}
