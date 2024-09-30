using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class playerDetection : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int currCount = int.Parse(text.text);
            currCount++;
            text.text = currCount.ToString();
            this.enabled = false;
        }
    }
}