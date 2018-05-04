using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public Transform targetTr;       //追踪的游戏对象的Transform
    public float dist = 10.0f;       //摄像机与目标的水平距离
    public float height = 3.0f;      //摄像机高度
    public float dampTrace = 20.0f;  //实现平滑追踪的变量

    //摄像机的Transform
    private Transform tr;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //目标停止移动后才调用，可以避免相机抖动
    void LateUpdate()
    {
        //保存相机在目标后方dist，高height的位置
        //Lerp函数进行插值运算，达到一个平滑的效果
        tr.position = Vector3.Lerp(tr.position, 
                                   targetTr.position - (targetTr.forward * dist) + (Vector3.up * height), 
                                   Time.deltaTime * dampTrace);
        //使相机朝向目标
        tr.LookAt(targetTr.position);
    }
}
