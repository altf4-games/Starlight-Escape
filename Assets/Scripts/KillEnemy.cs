using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.transform.name);
        if (other.CompareTag("Enemy"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<XP>().AddXP(50);
            AudioManager.instance.PlayAudio(AudioManager.instance.explosionSound, 0.8f, true, 1000f, other.transform.position);
            Destroy(other.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            Destroy(explosion, 1.5f);
        }
    }
}
