using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public GameObject explosionPrefab;
    public SpriteRenderer[] spriteRenderers;
    public GameObject engine;
    public Image healthBar;
    public AudioClip explosionSound;

    private void Start()
    {
        maxHealth = PlayerPrefs.GetInt("PlayerHealth", 100);
        health = maxHealth;
        Debug.Log("Player Health: " + maxHealth);
    }

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
        AudioManager.instance.PlayAudio(AudioManager.instance.explosionSound, 0.8f, true, 100f, transform.position);
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.enabled = false;
        }
        engine.SetActive(false);
        // Reload the scene
        Invoke("ReloadGame", 2.25f);
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("PlayerHealth", maxHealth);
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
