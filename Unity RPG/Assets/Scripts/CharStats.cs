using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour {

    public string charName;
    public int playerLevel = 1;
    public int currentEXP = 0;
    public int[] expToNextLevel;
    public int maxLevel;

    public int baseEXP = 1000;


    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] MpLvlBonus;

    public int charSTR;
    public int charDEF;
    public int wpnPwr;
    public int armorPwr;
    public string nameEquippedWeapon;
    public string nameEquippedArmor;
    public Sprite charImg;


	// Use this for initialization
	void Start () {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(1000);
        }
	}

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;

        if (playerLevel < maxLevel)
        {
            if (currentEXP >= expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];
                playerLevel++;

                if (playerLevel % 2 == 0)
                {
                    charSTR++;
                }
                else
                {
                    charDEF++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxMP = maxMP + MpLvlBonus[playerLevel];
                currentMP = maxMP;
            }
        }

        if(playerLevel == maxLevel)
        {
            currentEXP = 0;
        }
    }
}
