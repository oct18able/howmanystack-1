using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControll : Droppers {

    AudioSource breakSound; //ブロックが範囲外に落ちた時の音

	// Use this for initialization
	void Start () {
        breakSound = GetComponent<AudioSource>();   //AudioSourceを取得
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))   //Escapeキーを押すとゲームをリセットする
        {
            GameReset();
        }
	}

    //private GameObject _parent;

    private void OnTriggerEnter(Collider other) //ドロップが範囲外に落ちた際の判定
    {
        if (other.gameObject.tag == "Drop")
        {
            //Debug.Log("BelowTrigger");
            
            stackingNum = stackingNum - 1;  //積み上げの数を1つ減らす

            
            //オブジェクトを消去する            
            Destroy(other.gameObject);
            
            //範囲外になったという音の再生
            breakSound.Play();
        }
    }


    void GameReset()    //ゲームをリセットする
    {
        //落とした数、積み上げた数を初期状態にする
        up_count = 0;
        stackingNum = 0;

        //ゲームの再読込
        SceneManager.LoadScene("Main");
    }
    


}
