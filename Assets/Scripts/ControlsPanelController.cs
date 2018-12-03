using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlsPanelController : MonoBehaviour {

    DOTweenAnimation tween;

	// Use this for initialization
	void Start () {
        tween = GetComponent<DOTweenAnimation>();
	}
	
	public void OpenPanel()
    {
        tween.DORestart();
    }

    public void ClosePanel()
    {
        tween.DOPlayBackwards();
    }
}
