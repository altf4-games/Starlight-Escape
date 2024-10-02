using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum Planets
{
    Earth,
    Mars,
    Jupiter,
    Saturn,
    Uranus,
    Neptune,
    Pluto
}

public class playerDetection : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Planets planet;

    private void Start()
    {
        text.text = PlayerPrefs.GetInt("PlayerCount", 0).ToString();
        if (PlayerPrefs.HasKey(planet.ToString()))
        {
            Destroy(this);
        }
        Debug.Log("PlayerCount: " + text.text);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int currCount = int.Parse(text.text);
            currCount++;
            text.text = currCount.ToString();
            SaveProgress();
            Destroy(this);
        }
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetInt("PlayerCount", int.Parse(text.text));
        PlayerPrefs.SetString(planet.ToString(), planet.ToString());
    }
}