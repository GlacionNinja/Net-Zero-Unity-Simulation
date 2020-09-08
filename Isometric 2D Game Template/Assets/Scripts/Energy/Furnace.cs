using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Furnace : MonoBehaviour
{
    private int tempOutside;
    private int tempInside;
    private int airDensity = 1275;
    private int specificHeat = 1;
    private int squareFootage;
    private int averageHeightPerRoom;
    private int rvalue;

    private void Start()
    {
        Furnace2(tempOutside, tempInside, squareFootage, averageHeightPerRoom, rvalue);
    }

    private void Update()
    {
        
    }

    public void Furnace2(int tempOut = 21, int tempIn = 19, int sqaureFoot = 2000, int averageHeight = 7, int rvalue1 = 28)
    {
        tempOutside = tempOut;
        tempInside = tempIn;
        squareFootage = sqaureFoot;
        averageHeightPerRoom = averageHeight;
        rvalue = rvalue1;
    }
    private int heatLost()
    {
        return (squareFootage * (tempOutside - tempInside)) / rvalue;
    }
    private int getVolume()
    {
        // determine an efficient way to get volume of house
        return squareFootage * averageHeightPerRoom;
    }
    private int heatNeeded(int tempOutside)
    {
        // energy = mcdeltat, mass of air is airDensity * getVolume(),  is specificHeat
        return (specificHeat * airDensity * getVolume() * (tempOutside - tempInside)) + heatLost();

    }
    public double calcEnergyUse()
    {
        //temp = getOutside(); // o
        return heatNeeded(tempOutside);
    }
}