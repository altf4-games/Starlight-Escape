using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health = 100;
    public GameObject explosionPrefab;
    public SpriteRenderer[] spriteRenderers;
    public GameObject engine;
    public Image healthBar;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 1.5f);
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.enabled = false;
        }
        engine.SetActive(false);
        // Reload the scene
        Invoke("ReloadGame", 2.25f);
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        healthBar.fillAmount = health / 100f;
    }
}
