using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    public static GameControl gameControl;
    public Text scoreText;
    public GameObject lifePrefab;
    public GameObject snakePrefab;
    public GameObject gameOverPrefab;
    public Transform lifePoint;
    public int lifeTotal;
    GameObject snake;
    public List<GameObject> allLife;
    int currentScore = 0;
    // Start is called before the first frame update
    void Awake()
    {
        gameControl = this;
        ScoreUp(0);
        Setup();
    }

    void Setup()
    {
        snake = Instantiate(snakePrefab);
        if (allLife.Count < 1)
        {
            for (int i = 0; i < lifeTotal; i++)
            {
                GameObject life = Instantiate(lifePrefab, lifePoint.transform, false);
                allLife.Add(life);
            }
        }
    }

    public void CheckLife()
    {
        lifeTotal--;
        if (lifeTotal > 0)
        {
            RemoveLife();
            Setup();
        }
        else
        {
            RemoveLife();
            GameObject overPopup = Instantiate(gameOverPrefab,transform, false);
        }
    }

    void RemoveLife()
    {
        Destroy(allLife[lifeTotal]);
        allLife.RemoveAt(lifeTotal);
        TailMovement[] tails = FindObjectsOfType<TailMovement>();
        foreach (TailMovement t in tails)
        {
            Destroy(t.gameObject);
        }

        Destroy(snake);
      
    }

  

    public void ScoreUp(int s)
    {
        currentScore = currentScore + s;
        scoreText.text = "Score :" + currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
