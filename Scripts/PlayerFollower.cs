using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    // breytur, leikmadur og fjarlaegd
    public Transform player;
    public Vector3 offset;

    // myndavel fylgir leikmanni med bili
    void Update()
    {
        transform.position = player.position + offset;
        transform.rotation = player.rotation;
    }
}
