using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int curLevel = 1;

    public FaderController fader;

    // Use this for initialization
    void Awake () {

        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        //Init();
    }

    public void Init()
    {
        StartCoroutine("FindFader");

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
        yield return new WaitForSeconds(2f);
        fader.FadeIntoBlack();
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(curLevel - 1);

        yield return false;
    }

    public void GameOver()
    {
        StartCoroutine("GameOverRoutine");
    }

    IEnumerator GameOverRoutine()
    {
        fader.FadeIntoBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return false;
    }

    IEnumerator FindFader()
    {
        yield return new WaitForSeconds(1f);
        fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderController>();

        if (fader != null) {
            yield return false;
        }

        yield return true;
    }
}
