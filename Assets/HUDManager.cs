using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    Text ammoText;
    Image healthBar;
    Image staminaBar;
	void Start () {
        ammoText = GetComponentInChildren<Text>();
        Image[] bars = GetComponentsInChildren<Image>();
        healthBar = bars[0];
        staminaBar = bars[1];
	}
	
	// Update is called once per frame
	void Update () {
        string ammoAmount = "";
        ammoAmount = GameManager.player.currentWeapon.ammoInClip.ToString();
        ammoText.text = ammoAmount;
        healthBar.fillAmount = GameManager.player.health / 100;
        staminaBar.fillAmount = GameManager.player.gameObject.GetComponent<Movement>().stamina / 100;
	}
}
