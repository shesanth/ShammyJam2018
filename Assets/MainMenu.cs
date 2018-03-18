using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject mainPanel;
	public GameObject creditsPanel;
	public GameObject controlsPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void activateCredits(){
		mainPanel.SetActive(false);
		creditsPanel.SetActive(true);
	}

	public void deactivateCredits(){
		mainPanel.SetActive(true);
		creditsPanel.SetActive(false);
	}

	public void activateControls(){
		mainPanel.SetActive(false);
		controlsPanel.SetActive(true);
	}

	public void playNext(){
		SceneManager.LoadScene(1);
	}

	public void quit(){
		Application.Quit();
	}

	// public IEnumerator FadeScreenToNext()
	// {
	// 	white.SetActive (true);
	// 	Image i = white.GetComponent<Image> ();
	// 	i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
	// 	while (i.color.a < 1.0f)
	// 	{
	// 		i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime));
	// 		yield return null;
	// 	}
	// 	SceneManager.LoadScene (1);
	// }
}
