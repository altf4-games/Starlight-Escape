using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        string name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!PlayerPrefs.HasKey(name))
        {
            PlayerPrefs.SetString(name, name);
        }
    }

}