using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData {

    //credits
    public int credits;

    //grass blocks
    public float[] grassBlockPosX;
    public float[] grassBlockPosY;
    public int[] grassBlockSorting;

    //plants
    public String[] plantName;
    public float[] plantPosX;
    public float[] plantPosY;
    public float[] growthTimer;
    public int[] growthStage;
    public int[] sortingLayer;
}
