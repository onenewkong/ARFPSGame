using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject gameLabel;

    Text gameText;

    GunCtrl gun;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public enum GameState
    {
        Ready,
        Run,
        GameOver
    }

    public GameState gState;

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();
        gameText.text = "Ready...";
        gameText.color = new Color32(255, 255, 255, 255);

        StartCoroutine(ReadyToStart());

        gun = GameObject.Find("Gun").GetComponent<GunCtrl>();
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);

        gameText.text = "Go!";

        yield return new WaitForSeconds(0.5f);

        gameLabel.SetActive(false);

        gState = GameState.Run;
    }
  
    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.Instance.GetScore() >= 100)
        {
            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color32(255, 0, 0, 255);
            gState = GameState.GameOver;
        }
    }
}
