using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuController : MonoBehaviour {

    FaderController fader;

    private void Start()
    {
        fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderController>();
    }

    public void PlayGame()
    {
        StartCoroutine("PlayGameRoutine");
    }

    IEnumerator PlayGameRoutine()
    {
        fader.FadeIntoBlack();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
        yield return false;
    }
}
