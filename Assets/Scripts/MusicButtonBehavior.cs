using UnityEngine;
using System.Collections;

public class MusicButtonBehavior : MonoBehaviour {
	
	public Texture2D buttonOnTexture = null;
	
	public Texture2D buttonOffTexture = null;
	
	public static int musicSetting;
	/* 0 : music on
	 * 1 : music off
	 */
	
	void Start() {
		musicSetting = PlayerPrefs.GetInt ("musicsetting", 0);
	}
	
	void setAudio(int setting) {
		PlayerPrefs.SetInt ("musicsetting", setting);
		PlayerPrefs.Save ();
	}
	
	void OnGUI() {
		if (StartButtonBehavior.beginning == true || RetryButtonBehavior.end == true) {
			if (musicSetting == 0) {
				if (Screen.width <= 640 && Screen.height <= 960) {
					if (GUI.Button(new Rect(Screen.width - 140, 0, 70, 70), buttonOnTexture)) {
						musicSetting = 1;
						setAudio (musicSetting);
					}
				} else {
					if (GUI.Button(new Rect(Screen.width - 200, 0, 100, 100), buttonOnTexture)) {
						musicSetting = 1;
						setAudio (musicSetting);
					}
				}
			} else {
				if (Screen.width <= 640 && Screen.height <= 960) {
					if (GUI.Button(new Rect(Screen.width - 140, 0, 70, 70), buttonOffTexture)) {
						musicSetting = 0;
						setAudio (musicSetting);
					}
				} else {
					if (GUI.Button(new Rect(Screen.width - 200, 0, 100, 100), buttonOffTexture)) {
						musicSetting = 0;
						setAudio (musicSetting);
					}
				}
			}
		}
	}
}