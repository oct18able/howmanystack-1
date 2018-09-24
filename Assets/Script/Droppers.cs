using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppers : MonoBehaviour {

    public GameObject[] dropitem;   //落とすドロップを格納
    public static int up_count = 0; //落とした数
    public static int stackingNum = 0;  //現在積み上げた数


    GameObject drop ;   //落とすドロップ
    Vector3 defaultPosition;    //ドロップ出現初期位置

    
    // Use this for initialization
    void Start () {
        
        drop = Instantiate(ChooseDrop(), GetDropPosition(), Quaternion.identity);   //初期ドロップを作る
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))   //ボタンを押すと落とす
        {
            Drop();
        }

        Move(); //移動させる

    }


    GameObject ChooseDrop() //ランダムに落とすブロックを選ぶ
    {
        GameObject prefab = null;
        int index = Random.Range(0, dropitem.Length);
        prefab = dropitem[index];
        up_count++; //落とした数を1つ増加
        stackingNum++;  //積み上げた数を1増加
        return prefab;
    }

    Vector3 GetDropPosition()   //ドロップの出現位置を決める
    {
        defaultPosition = transform.position;   //ドロップ出現位置を保存しておく
        return transform.position;
    }

    public void Drop()  //ドロップを落とす
    {
        Rigidbody dropRb = drop.GetComponent<Rigidbody>();
        dropRb.useGravity = true;
        drop.transform.parent = GameObject.Find("AlreadyDrop").transform;   //落としたものは、AlreadyDrop(のGameObjct)の子とする

        //コルーチンで1秒後に別のドロップを出現させる(落としたドロップと新たなドロップが干渉しないようにするため)
        StartCoroutine(Delay(1.0f));    
    
    }

    private IEnumerator Delay(float waitTime)   //新たなドロップを作る
    {
        yield return new WaitForSeconds(waitTime);  //指定時間待機させる(落としたドロップと新たなドロップが干渉しないようにするため)
        drop = Instantiate(ChooseDrop(), GetDropPosition(), Quaternion.identity);   //新たなドロップを出現させる

    }

    public void Move()  //落とす前のドロップの移動
    {
        //x方向、y方向の取得
        float drop_X = Input.GetAxis("Horizontal");
        float drop_Y = Input.GetAxis("Vertical");
       
        //ドロップを移動させる
        drop.transform.Translate(drop_X * Time.deltaTime * 5, 0, 0);
        drop.transform.Translate(0, drop_Y * Time.deltaTime * 5, 0);

        //ドロップが範囲外に移動しすぎないために制限をかける
        drop.transform.position = new Vector3(Mathf.Clamp(drop.transform.position.x, -10.0f, 10.0f), Mathf.Clamp(drop.transform.position.y, 5.0f, 13.0f), 0);

        //Eを押すと右回転、Qを押すと左回転
        if (Input.GetKey(KeyCode.E))
        {
            drop.transform.Rotate(0, 0, -Time.deltaTime * 75);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            drop.transform.Rotate(0, 0, Time.deltaTime * 75);
        }

        //Rを押すと、出現初期位置に移動
        if (Input.GetKey(KeyCode.R))
        {
            PositionReset();
        }

    }

    public void PositionReset() //出現初期位置に移動
    {
        drop.transform.position = defaultPosition;
        drop.transform.rotation = Quaternion.Euler(0, 0, 0);
    }



}
