using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    // saekir breytuna LoadNextLevel til ad fara i naesta level
    void OnTriggerEnter()
    {
        gameManager.LoadNextLevel();
    }
}
