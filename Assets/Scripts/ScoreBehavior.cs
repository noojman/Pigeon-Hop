using UnityEngine;
using System.Collections;

public class ScoreBehavior : MonoBehaviour {

	public static Font myFont;

	public static int show = 2;
	/* 0 : end
	 * 1 : in-game
	 * 2 : menus
	 */

	void Start() {
		myFont = Resources.Load ("Comfortaa-Bold", typeof(Font)) as Font;
	}

	public static GUIStyle scoreStyle = null;
	public static GUIStyle endStyle = null;
	public static int points;

	public static void Setup() {
		points = 0;
		endStyle = new GUIStyle ();
		if (Screen.width <= 640 && Screen.height <= 960) {
			endStyle.fontSize = 30;
		} else {
			endStyle.fontSize = 60;
		}
		endStyle.font = myFont;
		endStyle.normal.textColor = Color.yellow;
		scoreStyle = new GUIStyle ();
		if (Screen.width <= 640 && Screen.height <= 960) {
			scoreStyle.fontSize = 175;
		} else {
			scoreStyle.fontSize = 350;
		}
		scoreStyle.font = myFont;
		scoreStyle.normal.textColor = new Color (255, 255, 255, 0.3f);
		show = 1;
	}

	public static void addPoint() {
		points += 1;
	}

	public static void SaveScore() {
		int oldHighscore = PlayerPrefs.GetInt ("highscore", 0);
		if (points > oldHighscore) {
			PlayerPrefs.SetInt ("highscore", points);
		}
		PlayerPrefs.Save ();
	}

	void OnGUI() {
		if (Screen.width <= 640 && Screen.height <= 960) {
			if (show == 1 && BirdBehavior.instructions == false) {
				string text = "" + points;
				int length = text.Length * 95;
				int counter = 0;
				for (int i = 0; i < text.Length; i++) {
					if (text.Substring (i, 1).Equals ("1")) {
						counter++;
					}
				}
				length -= (counter * 30);
				if (points < 10) {
					GUI.Label (new Rect(Screen.width / 2 - length / 2, 60, 200, 200), "" + points, scoreStyle);
				} else if (points < 100) {
					GUI.Label (new Rect(Screen.width / 2 - length / 2, 60, 200, 200), "" + points, scoreStyle);
				} else if (points < 1000) {
					GUI.Label (new Rect(Screen.width / 2 - length / 2, 60, 200, 200), "" + points, scoreStyle);
				} else {
					GUI.Label (new Rect(Screen.width / 2 - length / 2, 60, 200, 200), "" + points, scoreStyle);
				}
			} else if (show == 0) {
				// TODO try to find a less hard-coded solution to aligning the score text
				if (PlayerPrefs.GetInt ("highscore", 0) < 10) {
					GUI.Label (new Rect(Screen.width / 2 - 110, Screen.height / 3 - 50, 50, 5), "YOUR SCORE: " + points, endStyle);
					GUI.Label (new Rect(Screen.width / 2 - 95, Screen.height / 3, 100, 10), "HIGH SCORE: " + PlayerPrefs.GetInt ("highscore", 0), endStyle);
				} else if (PlayerPrefs.GetInt ("highscore", 0) < 100) {
					GUI.Label (new Rect(Screen.width / 2 - 120, Screen.height / 3 - 50, 50, 5), "YOUR SCORE: " + points, endStyle);
					GUI.Label (new Rect(Screen.width / 2 - 105, Screen.height / 3, 100, 10), "HIGH SCORE: " + PlayerPrefs.GetInt ("highscore", 0), endStyle);
				} else if (PlayerPrefs.GetInt ("highscore", 0) < 1000) {
					GUI.Label (new Rect(Screen.width / 2 - 128, Screen.height / 3 - 50, 50, 5), "YOUR SCORE: " + points, endStyle);
					GUI.Label (new Rect(Screen.width / 2 - 113, Screen.height / 3, 100, 10), "HIGH SCORE: " + PlayerPrefs.GetInt ("highscore", 0), endStyle);
				} else {
					GUI.Label (new Rect(Screen.width / 2 - 135, Screen.height / 3 - 50, 50, 5), "YOUR SCORE: " + points, endStyle);
					GUI.Label (new Rect(Screen.width / 2 - 120, Screen.height / 3, 100, 10), "HIGH SCORE: " + PlayerPrefs.GetInt ("highscore", 0), endStyle);
				}
			}
		} else {
			if (show == 1 && BirdBehavior.instructions == false) {
				string text = "" + points;
				int length = text.Length * 190;
				int counter = 0;
				for (int i = 0; i < text.Length; i++) {
					if (text.Substring (i, 1).Equals ("1")) {
						counter++;
					}
				}
				length -= (counter * 60);
				if (points < 10) {
					GUI.Label (new Rect(Screen.width / 2 - length / 2, 60, 400, 400), "" + points, scoreStyle);
				} else if (points < 100) {
					GUI.Label (new Rect(Screen.width / 2 - length / 2, 60, 400, 400), "" + points, scoreStyle);
				} else if (points < 1000) {
					GUI.Label (new Rect(Screen.width / 2 - length / 2, 60, 400, 400), "" + points, scoreStyle);
				} else {
					GUI.Label (new Rect(Screen.width / 2 - length / 2, 60, 400, 400), "" + points, scoreStyle);
				}
			} else if (show == 0) {
				// TODO try to find a less hard-coded solution to aligning the score text
				if (PlayerPrefs.GetInt ("highscore", 0) < 10) {
					GUI.Label (new Rect(Screen.width / 2 - 220, Screen.height / 3 - 100, 100, 10), "YOUR SCORE: " + points, endStyle);
					GUI.Label (new Rect(Screen.width / 2 - 190, Screen.height / 3, 100, 10), "HIGH SCORE: " + PlayerPrefs.GetInt ("highscore", 0), endStyle);
				} else if (PlayerPrefs.GetInt ("highscore", 0) < 100) {
					GUI.Label (new Rect(Screen.width / 2 - 240, Screen.height / 3 - 100, 100, 10), "YOUR SCORE: " + points, endStyle);
					GUI.Label (new Rect(Screen.width / 2 - 210, Screen.height / 3, 100, 10), "HIGH SCORE: " + PlayerPrefs.GetInt ("highscore", 0), endStyle);
				} else if (PlayerPrefs.GetInt ("highscore", 0) < 1000) {
					GUI.Label (new Rect(Screen.width / 2 - 255, Screen.height / 3 - 100, 100, 10), "YOUR SCORE: " + points, endStyle);
					GUI.Label (new Rect(Screen.width / 2 - 225, Screen.height / 3, 100, 10), "HIGH SCORE: " + PlayerPrefs.GetInt ("highscore", 0), endStyle);
				} else {
					GUI.Label (new Rect(Screen.width / 2 - 270, Screen.height / 3 - 100, 100, 10), "YOUR SCORE: " + points, endStyle);
					GUI.Label (new Rect(Screen.width / 2 - 240, Screen.height / 3, 100, 10), "HIGH SCORE: " + PlayerPrefs.GetInt ("highscore", 0), endStyle);
				}
			}
	}
	}
}