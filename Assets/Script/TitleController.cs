using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //この関数はボタンに組み込む
    public void OnStartButtonClicked()  //この関数が作動するとMain(Scene)へ移行し、ゲームを開始する
    {
        SceneManager.LoadScene("Main");
    }


}
