using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHeadCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Collider
    private void OnCollisionEnter2D(Collision2D col)
    {
        // 頭が接触した時
        if (col.transform.tag == "Body")
        {
            //---------------------------------------------------------------------------------------------------------------
            //? 頭を体の指定地点に移動させる
            //\ 合体アニメーションを入れる予定
            GameObject n_Head = this.gameObject.transform.root.gameObject;
            GameObject n_colBody = col.transform.root.gameObject;

            // 頭の座標を初期化
            n_Head.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            // 指定地点の子供にする
            n_Head.transform.parent = n_colBody.GetComponent<CBodyBase>().m_objSetHead.transform;

            // 頭の重力をなくす
            n_Head.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            //---------------------------------------------------------------------------------------------------------------
        }
    }
}
