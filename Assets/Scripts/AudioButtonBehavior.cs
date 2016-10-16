using UnityEngine;
using System.Collections;

public class AudioButtonBehavior : MonoBehaviour {
	
	public Texture2D buttonOnTexture = null;

	public Texture2D buttonOffTexture = null;

	public static int audioSetting;
	/* 0 : audio on
	 * 1 : audio off
	 */

	void Start() {
		audioSetting = PlayerPrefs.GetInt ("audiosetting", 0);
	}

	void setAudio(int setting) {
		PlayerPrefs.SetInt ("audiosetting", setting);
		PlayerPrefs.Save ();
	}

	void OnGUI() {
		if (StartButtonBehavior.beginning == true || RetryButtonBehavior.end == true) {
			if (audioSetting == 0) {
				if (Screen.width <= 640 && Screen.height <= 960) {
					if (GUI.Button(new Rect(Screen.width - 70, 0, 70, 70), buttonOnTexture)) {
						audioSetting = 1;
						setAudio (audioSetting);
						if (BirdBehavior.audioAmbience.isPlaying) {
							BirdBehavior.audioAmbience.Stop ();
						}
					}
				} else {
					if (GUI.Button(new Rect(Screen.width - 100, 0, 100, 100), buttonOnTexture)) {
						audioSetting = 1;
						setAudio (audioSetting);
						if (BirdBehavior.audioAmbience.isPlaying) {
							BirdBehavior.audioAmbience.Stop ();
						}
					}
				}
			} else {
				if (Screen.width <= 640 && Screen.height <= 960) {
					if (GUI.Button(new Rect(Screen.width - 70, 0, 70, 70), buttonOffTexture)) {
						audioSetting = 0;
						setAudio (audioSetting);
						if (!BirdBehavior.audioAmbience.isPlaying) {
							BirdBehavior.audioAmbience.Play ();
						}
					}
				} else {
					if (GUI.Button(new Rect(Screen.width - 100, 0, 100, 100), buttonOffTexture)) {
						audioSetting = 0;
						setAudio (audioSetting);
						if (!BirdBehavior.audioAmbience.isPlaying) {
							BirdBehavior.audioAmbience.Play ();
						}
					}
				}
			}
		}
	}
}