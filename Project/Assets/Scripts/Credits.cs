using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

    public Text text;
    public int startingCredits;
    private static int credits;

	void Start () {
        credits = startingCredits;
	}
	
	void Update () {
        text.text = credits.ToString();
	}

    public static void increaseCredits(int moreCredits)
    {
        credits += moreCredits;
    }

    public static void decreaseCredits(int lessCredits)
    {
        credits -= lessCredits;
    }

    public static int getCredits()
    {
        return credits;
    }

    public static void setCredits(int newCredits)
    {
        credits = newCredits;
    }
}
