using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_manager : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GameOver;
    public GameObject gameOverpanel;

    public static bool Started;
    public GameObject textmulai;


    void Start()
    {
        GameOver   = false;
        Time.timeScale = 1.0f;
        Started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Time.timeScale = 0;
            gameOverpanel.SetActive(true);
        }

        if (SwipeManager.tap)
        {
            Started = true;
            //textmulai.SetActive(false);
            Destroy(textmulai);
        }
    }
}
