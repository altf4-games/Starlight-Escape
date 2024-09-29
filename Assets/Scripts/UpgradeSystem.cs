using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject panel;

    private XP playerXP;
    private PlayerHealth playerHealth;
    private PlayerAttacks playerAttacks;
    private ExampleShipControl playerShipControl;

    private void Start()
    {
        // Cache references to necessary components at the start
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerXP = player.GetComponent<XP>();
            playerHealth = player.GetComponent<PlayerHealth>();
            playerAttacks = player.GetComponent<PlayerAttacks>();
            playerShipControl = player.GetComponent<ExampleShipControl>();
        }
    }

    public void OpenPanel()
    {
        if (playerXP != null)
        {
            text.text = "Points: " + playerXP.upgradePoints.ToString();
        }
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void UpgradeHealth()
    {
        if (playerXP == null || playerHealth == null || playerXP.upgradePoints <= 0)
        {
            return;
        }

        playerXP.upgradePoints -= 1;
        playerHealth.maxHealth += 50;
        playerHealth.health = playerHealth.maxHealth;  // Update health to max health
        ClosePanel();
    }

    public void UpgradeAttackCooldown()
    {
        if (playerXP == null || playerAttacks == null || playerXP.upgradePoints <= 0)
        {
            return;
        }

        playerXP.upgradePoints -= 1;
        playerAttacks.projectileCooldown *= 0.75f;  // Reduce cooldown by 25%
        ClosePanel();
    }

    public void UpgradeShieldCooldown()
    {
        if (playerXP == null || playerAttacks == null || playerXP.upgradePoints <= 0)
        {
            return;
        }

        playerXP.upgradePoints -= 1;
        playerAttacks.shieldCooldown *= 0.75f;  // Reduce cooldown by 25%
        ClosePanel();
    }

    public void UpgradeThrusterMaxSpeed()
    {
        if (playerXP == null || playerShipControl == null || playerXP.upgradePoints <= 0)
        {
            return;
        }

        playerXP.upgradePoints -= 1;
        playerShipControl.max_thrust *= 1.25f;  // Increase max thrust by 25%
        ClosePanel();
    }
}
