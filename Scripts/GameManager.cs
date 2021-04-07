using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public int count;
    public Text countText;


    public void EndGame()
    {
        // if setning svo leikurinn sé ekki endalaust endurræstur
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Endurræsa();
        }
    }

    // breytir counts i fyrrum safnada coins svo það sýnir heildina
    public int Check()
    {
        count = PlayerPrefs.GetInt("PlayerCurrentCoins");
        return count;
    }
    // telur fjölda coins
    public void CountCoins(int nr)
    {
        Check();
        count = count + nr;
        PlayerPrefs.SetInt("PlayerCurrentCoins", count);
        Debug.Log("Nú er ég komin með " + count);
        SetCountText();//kallar á fallið;
        

        
    }

    // sýnir fjölda coins á skjánum
    public void SetCountText()
    {
        countText.text = "Stig: " + PlayerPrefs.GetInt("PlayerCurrentCoins").ToString();
    }

    // byrjar næsta level
    public void LoadNextLevel()
    {
        PlayerPrefs.SetInt("PlayerCurrentCoins", count);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    // breyta sem endurræsir leikin
    public void Endurræsa()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("PlayerCurrentCoins", 0);
    }
}
