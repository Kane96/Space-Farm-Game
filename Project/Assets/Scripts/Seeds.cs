using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seeds : MonoBehaviour
{

    public bool isFlower = false;
    public int buyingValue;
    public int sellingValue;
    public int sortingLayer;
    public int totalTileSize;
    public int growthStage = 0;
    public float growingSpeedInSecs;
    public Sprite[] growingSprites;
    public bool finishedGrowing = false;
    public GameObject sparkler;
    public List<GrassBlockPlanting> grassList = new List<GrassBlockPlanting>();
    public string buttonPriceObjectName;
    public GameObject priceGameObject;
    public PriceManager priceManager;
    public float timer;

    private ParticleSystem particles;
    public bool moduleEnabled;

    private GameObject sparkle;
    private SpriteRenderer sprites;
    private PolygonCollider2D poly;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        sprites = gameObject.GetComponent<SpriteRenderer>();
        poly = gameObject.GetComponent<PolygonCollider2D>();

        priceGameObject = GameObject.Find(buttonPriceObjectName);
        priceManager = priceGameObject.GetComponent<PriceManager>();
        Credits.decreaseCredits(priceManager.currentPrice);
        priceManager.increasePrice();

        foreach (GrassBlockPlanting grassScript in grassList)
        {
            grassScript.gridEmpty = false;
        }
        if (!isFlower)
        {
            sprites.sprite = growingSprites[growthStage];
        }
    }

    void Update()
    {
        sprites.sortingOrder = sortingLayer;
        if (!isFlower)
        {
            timer += (1 * Time.deltaTime);
            if (growthStage >= growingSprites.Length - 1)
            {
                finishedGrowing = true;
            }
            if (!finishedGrowing)
            {
                if (timer > growingSpeedInSecs)
                {
                    growthStage++;
                    sprites.sprite = growingSprites[growthStage];
                    timer = 0;
                }
            }
        }
    }

    public void OnMouseDown()
    {
        if (SeedSelect.currentObjectSelected == null)
        {
            replant();
        }
    }

    public void replant()
    {
        if (finishedGrowing && !isFlower)
        {
            sparkle = Instantiate(sparkler, transform.position, Quaternion.identity) as GameObject;
            sparkle.GetComponent<SpriteRenderer>().sortingOrder = sortingLayer + 1;
            growthStage = 0;
            sprites.sprite = growingSprites[0];
            finishedGrowing = false;
            timer = 0;
            Credits.increaseCredits(sellingValue);
        }
    }

    public void digUp()
    {
        foreach (GrassBlockPlanting grassScript in grassList)
        {
            grassScript.gridEmpty = true;
        }
        priceManager.decreasePrice();
        Destroy(gameObject);
    }
}