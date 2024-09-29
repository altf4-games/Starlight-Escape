using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP : MonoBehaviour
{
    public int xp;
    public int level = 1;
    public int xpToLevelUp = 1000;
    public int upgradePoints = 0;
    public Image image;

    private void Start()
    {
        SurvivalPoints();
    }

    private void SurvivalPoints()
    {
        AddXP(5);
        Invoke("SurvivalPoints", 1f);
    }

    public void AddXP(int xp)
    {
        this.xp += xp;
        image.fillAmount = (float)this.xp / xpToLevelUp;
        if (this.xp >= xpToLevelUp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        GetComponent<PlayerHealth>().health = GetComponent<PlayerHealth>().maxHealth;
        xp = 0;
        image.fillAmount = (float)xp / xpToLevelUp;
        xpToLevelUp = (int)(xpToLevelUp * 2.5f);
        upgradePoints++;
    }
}
