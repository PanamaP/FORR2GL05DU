using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // breyta sem byrjar leikin
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // tegar leik er lokid er haegt ad endurraesa hann
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("PlayerCurrentCoins", 0);
    }
}
