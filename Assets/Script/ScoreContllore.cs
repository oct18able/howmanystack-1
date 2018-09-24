using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContllore : Droppers {

    public Text howManyDrop;    //落とした数の表示用
    public Text howManyStack;   //積み上げた数の表示用

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //落とした数、積み上げた数を更新していく
        //用意した変数と表示のタイミング上、数を1つ減らしておく
        howManyDrop.text = "You Dropped : " + (up_count-1);
        howManyStack.text ="You Are Stacking : " + (stackingNum-1);
	}
}
