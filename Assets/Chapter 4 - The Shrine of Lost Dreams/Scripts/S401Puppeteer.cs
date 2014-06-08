﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S401Puppeteer : CutscenePuppeteer {

	private GameObject ChefTony;
	private MusicPlayer mus;

	//private Animator ctanim;

	// Use this for initialization
	void Start () {
		// get all the objects we'll need for the cutscene 
		ChefTony = GameObject.Find ("Chef Tony");
		mus = GameObject.Find ("BGM").GetComponent<MusicPlayer>();
		//ctanim = ChefTony.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
		if(CurrentScene == 3) {
			if(ChefTony.transform.position.x > 10.0f) {
				ChefTony.GetComponent<PlayerFreeze>().Freeze();
				nextScene();
			}
		} else if(CurrentScene == 6) {
			if(ChefTony.transform.position.x > 13.85f) {
				ChefTony.GetComponent<PlayerFreeze>().Freeze();
				StartCoroutine(FadeAndNext(Color.black, 2, "4-02 Temple Interior"));
				mus.StopMusic(2.0f);
				
				nextScene();
			}
		} 
	}

	public override void HandleSceneChange() {
		if(CurrentScene == 3 || CurrentScene == 6) {
			ChefTony.GetComponent<PlayerFreeze>().UnFreeze();
		}
	}

}
