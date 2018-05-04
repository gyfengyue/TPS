using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    private float h = 0.0f;
    private float v = 0.0f;
    private Transform tr;
    //移动速度
    public float moveSpeed = 10.0f;
    //旋转速度
    public float rotSpeed = 10.0f;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //向量计算得到一个运动的方向向量
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        //Translate( 移动方向 * 速度 * 位移值 * Time.deltaTime, 基础坐标)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);
        //以Vector3.up 轴为基准，以rotSpeed速度旋转
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));

	}
}
