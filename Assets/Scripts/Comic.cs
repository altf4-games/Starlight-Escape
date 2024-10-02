using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Comic : MonoBehaviour
{
    public GameObject comicPanel;
    public Image comicImage;
    public Sprite[] comicSprites;

    private int currentSprite = 0;

    private void Start()
    {
        comicPanel.SetActive(false);
    }

    public IEnumerator ShowComic()
    {
        comicPanel.SetActive(true);
        comicImage.sprite = comicSprites[currentSprite];
        yield return null;
        // yield return new WaitForSeconds(7f);
        // NextSprite();
        // yield return new WaitForSeconds(7f);
        // NextSprite();
        // yield return new WaitForSeconds(7f);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextSprite()
    {
        currentSprite++;
        if (currentSprite >= comicSprites.Length)
        {
            //comicPanel.SetActive(false);
            //currentSprite = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            comicImage.sprite = comicSprites[currentSprite];
        }
    }

    public void PreviousSprite()
    {
        currentSprite--;
        if (currentSprite < 0)
        {
            currentSprite = 0;
        }
        else
        {
            comicImage.sprite = comicSprites[currentSprite];
        }
    }

}
