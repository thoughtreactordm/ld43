using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int curLevel = 1;
    public int workingCoins;
    public int totalCoins;

    // Use this for initialization
    void Start () {

        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        workingCoins = 0;
        Debug.Log("Level Initialized!");
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Victory()
    {
        StartCoroutine("VictoryRoutine");
    }

    IEnumerator VictoryRoutine()
    {
        Debug.Log("Victory!");
        curLevel++;
        totalCoins += workingCoins;
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(curLevel - 1);

        yield return false;
    }

    public void GameOver()
    {
        StartCoroutine("GameOverRoutine");
    }

    IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return false;
    }
}
