using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHeadMove : MonoBehaviour
{
    private Rigidbody2D physics2D = null;
    [SerializeField] private LineRenderer m_lineRender;


    [SerializeField] private float MaxMagnitude = 2f;
    private Vector3 m_dragStart = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] private Vector2 currentForce = new Vector2(0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        physics2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// クリックされた時、実行する
    /// </summary>
    /// <returns></returns>
    public void OnMouseDown()
    {
        m_dragStart = this.GetMousePosition();

        m_lineRender.enabled = true;
    }

    /// <summary>
    /// ドラッグ中イベントハンドラ
    /// </summary>
    public void OnMouseDrag()
    {
        var position = this.GetMousePosition();
        //[f: id:matatabi_ux:20181020141708g:plain]
        this.currentForce = position - this.m_dragStart;
        //        if (this.currentForce.magnitude > MaxMagnitude * MaxMagnitude)
        //       {
        this.currentForce *= MaxMagnitude / this.currentForce.magnitude;
        //            Debug.Log("こっち");
        //       }


                Vector3 n_Force = new Vector3(this.currentForce.x*5f, this.currentForce.y * 5f, 0.0f);

        Debug.Log("x:" + float.IsNaN(this.physics2D.position.x) + "/ y:" + float.IsNaN(this.physics2D.position.y) + "/ z:");// + float.IsNaN(this.physics2D.position.z));

        var mainPos = new Vector3(this.physics2D.position.x, this.physics2D.position.y, 0.0f);
        m_lineRender.SetPosition(0, mainPos);
        m_lineRender.SetPosition(1, mainPos + n_Force);


        //                this.direction.SetPosition(0, this.physics.position);
        //        //        this.direction.SetPosition(1, this.physics.position + this.currentForce);
    }


    /// <summary>
    /// ドラッグ終了イベントハンドラ
    /// </summary>
    public void OnMouseUp()
    {
        //        this.direction.enabled = false;
        this.Flip(this.currentForce * 6f);

        m_lineRender.enabled = false;
    }

    /// <summary>
    /// ボールをはじく
    /// </summary>
    /// <param name="force"></param>
    private void Flip(Vector2 force)
    {
        // 瞬間的に力を加えてはじく
        this.physics2D.AddForce(force, ForceMode2D.Impulse);
    }

    /// <summary>
    /// マウス座標をワールド座標に変換して取得
    /// </summary>
    /// <returns></returns>
    private Vector3 GetMousePosition()
    {
        // マウスから取得できないZ座標を補完する
        var position = Input.mousePosition;
        position.z = Camera.main.transform.position.z;
        position = Camera.main.ScreenToWorldPoint(position);
        position.z = 0;

        return position;
    }
}
