using Boosters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoosterDataBase
{
    public static List<Booster> GetAllBoosters()
    {
        return new List<Booster>
        {
            new Booster
            {
                id = 11,
                image = "Images/Boosters/Booster11",
                boosterName = "Heroes of Azeroth",
                cost = 100
            }
        };
    }
}