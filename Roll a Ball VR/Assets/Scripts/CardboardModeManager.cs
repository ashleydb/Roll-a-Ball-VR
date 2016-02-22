using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardboardModeManager : MonoBehaviour {

	// We need a reference to camera which 
	// is how we get to the cardboard components.
	public GameObject cardboardMain;

	// This is to enable/disable the reticule
	private CardboardReticle cardboardReticle;

	public void Start()
	{
		// Save a flag in the local player preferences to initialize VR mode
		// This way when the app is restarted, it is in the mode that was last used.
		int doVR = PlayerPrefs.GetInt("VREnabled");
		Cardboard.SDK.VRModeEnabled = doVR == 1;
		CardboardHead head = cardboardMain.GetComponentInChildren<CardboardHead>();
		head.enabled = Cardboard.SDK.VRModeEnabled;
		cardboardReticle = cardboardMain.GetComponentInChildren<CardboardReticle>();
		cardboardReticle.gameObject.SetActive(Cardboard.SDK.VRModeEnabled);
		Cardboard.SDK.TapIsTrigger = true;
	}

	// The event handler to call to toggle Cardboard mode.
	public void ChangeCardboardMode()
	{
		CardboardHead head = cardboardMain.GetComponentInChildren<CardboardHead>();
		if (Cardboard.SDK.VRModeEnabled) {
			// disabling.  rotate back to the original rotation.
			head.transform.localRotation = Quaternion.identity;
		}
		Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
		head.enabled = Cardboard.SDK.VRModeEnabled;
		cardboardReticle.gameObject.SetActive(Cardboard.SDK.VRModeEnabled);
		PlayerPrefs.SetInt("VREnabled", Cardboard.SDK.VRModeEnabled?1:0);
		PlayerPrefs.Save();        
	}

	// The Cardboard SDK can show a back button, (escaspe key on keyboard,) which we will use to get out of VR view
	void Update () {
		if (Cardboard.SDK.BackButtonPressed) {
			ChangeCardboardMode();
		}
	}
}
