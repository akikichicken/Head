using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBodyBase : MonoBehaviour
{
    //? 現在はInspectorからオブジェクトを渡す。
    //\ のちに名前検索等をするか悩み中
    //public GameObject m_objSetHead { set; get; }
    public GameObject m_objSetHead;

    // Start is called before the first frame update
    void Start()
    {
        //        m_objSetHead=this.GetComponent<>
    }

    // Update is called once per frame
    void Update()
    {

    }
}
