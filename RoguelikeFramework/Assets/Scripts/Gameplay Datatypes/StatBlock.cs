﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatBlock
{
    public int maxHealth;
    public int ac; //Armor Class
    public int ev; //Evasion

    public static StatBlock operator +(StatBlock a, StatBlock b)
    {
        StatBlock toReturn = new StatBlock();
        toReturn.maxHealth = a.maxHealth + b.maxHealth;
        toReturn.ac = a.ac + b.ac;
        toReturn.ev = a.ev + b.ev;
        return toReturn;
    }

    public static StatBlock operator -(StatBlock a, StatBlock b)
    {
        StatBlock toReturn = new StatBlock();
        toReturn.maxHealth = a.maxHealth - b.maxHealth;
        toReturn.ac = a.ac - b.ac;
        toReturn.ev = a.ev - b.ev;
        return toReturn;
    }
}
