using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject shield;
    private bool shieldActive = false;
    private bool isShooting = false;
    public float shieldDuration = 5f;
    public float shieldCooldown = 10f;
    public float projectileSpeed = 500f;
    public float projectileCooldown = 0.1f;
    public GameObject projectileSpawnPositionL;
    public GameObject projectileSpawnPositionR;
    public GameObject projectilePrefab;
    public AudioClip shieldSound;
    public AudioClip projectileSound;

    // Start is called before the first frame update
    void Start()
    {
        shieldCooldown = PlayerPrefs.GetFloat("ShieldCooldown", 10f);
        projectileCooldown = PlayerPrefs.GetFloat("ProjectileCooldown", 0.1f);
        Debug.Log("Shield Cooldown: " + shieldCooldown);
        Debug.Log("Projectile Cooldown: " + projectileCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Right Mouse Button Clicked");
            ActivateShield();
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Left Mouse Button Clicked");
            FireProjectile();
        }
    }
    void FireProjectile()
    {
        if (isShooting)
        {
            return;
        }
        AudioManager.instance.PlayAudio(projectileSound, 0.8f, false);
        isShooting = true;
        GameObject projectileL = Instantiate(projectilePrefab, projectileSpawnPositionL.transform.position, projectileSpawnPositionL.transform.rotation);
        GameObject projectileR = Instantiate(projectilePrefab, projectileSpawnPositionR.transform.position, projectileSpawnPositionR.transform.rotation);
        projectileL.GetComponent<Rigidbody2D>().AddForce(projectileSpawnPositionL.transform.up * projectileSpeed);
        projectileR.GetComponent<Rigidbody2D>().AddForce(projectileSpawnPositionR.transform.up * projectileSpeed);
        Destroy(projectileL, 5f);
        Destroy(projectileR, 5f);
        StartCoroutine(ProjectileCooldown());
    }

    private IEnumerator ProjectileCooldown()
    {
        yield return new WaitForSeconds(projectileCooldown);
        isShooting = false;
    }

    void ActivateShield()
    {
        if (shieldActive)
        {
            return;
        }
        AudioManager.instance.PlayAudio(shieldSound, 0.8f, false);
        shieldActive = true;
        shield.SetActive(true);
        StartCoroutine(DeactivateShield());
    }

    public void SaveShieldCooldown()
    {
        PlayerPrefs.SetFloat("ShieldCooldown", shieldCooldown);
    }

    public void SaveProjectileCooldown()
    {
        PlayerPrefs.SetFloat("ProjectileCooldown", projectileCooldown);
    }

    IEnumerator DeactivateShield()
    {
        yield return new WaitForSeconds(shieldDuration);
        shield.SetActive(false);
        yield return new WaitForSeconds(shieldCooldown);
        shieldActive = false;
    }
}
