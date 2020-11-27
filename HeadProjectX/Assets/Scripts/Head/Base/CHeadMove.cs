using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHeadMove : MonoBehaviour
{
    private Vector3 screenToWorldPointPosition = new Vector3(0.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// クリックされた時、実行する
    /// </summary>
    /// <returns></returns>
    public void MouseClick()
    {
        screenToWorldPointPosition = this.gameObject.transform.root.transform.position;

        Debug.Log("Click" + screenToWorldPointPosition);
    }

    /// <summary>
    /// ドラッグされている時、実行する
    /// </summary>
    /// <returns></returns>
    public void MouseStayDrag()
    {
//        Debug.Log("イベント発生！"+ GetWorldPosMouse());
    }

    /// <summary>
    /// ドラッグをやめた、実行する
    /// </summary>
    /// <returns></returns>
    public void MouseExitDrag()
    {
        Vector3 n_pos = GetWorldPosMouse();
        n_pos -= this.gameObject.transform.position;
        Debug.Log("End" + n_pos);

//        Vector3 n_end = GetWorldPosMouse();

//        Vector3 n_judge = new Vector3(0.0f, 0.0f, 0.0f);
//        //        n_judge.x = screenToWorldPointPosition.x - n_end.x;
//        //        n_judge.y = screenToWorldPointPosition.y - n_end.y;

//        n_judge -=(n_end+screenToWorldPointPosition);

////        Debug.Log("Judge" + n_judge);
//        n_judge.Normalize();
//        Debug.Log("Start" + screenToWorldPointPosition + "End" + n_end + "Judge N" + n_judge);

        this.gameObject.transform.root.gameObject.GetComponent<Rigidbody2D>().velocity = n_pos.normalized;
    }

    /// <summary>
    /// ワールド座標のマウス
    /// </summary>
    /// <returns> Vector3型 </returns> 
    private Vector3 GetWorldPosMouse()
    {
        // Vector3でマウス位置座標を取得する
        Vector3 position = Input.mousePosition;
        // Z軸修正
        position.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        return Camera.main.ScreenToWorldPoint(position);
    }
}
