using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject text;
    public GameObject player;
    public GameObject button;
    public void Start()
    {
        text.SetActive(false);
        button.SetActive(false);
    }

    public void OnGameEnd()
    {
        text.GetComponent<Text>().text = "Przegrales";
        text.SetActive(true);
        player.transform.position = new Vector2(0,5);
        player.SetActive(false);
        button.SetActive(true);
    }
}
