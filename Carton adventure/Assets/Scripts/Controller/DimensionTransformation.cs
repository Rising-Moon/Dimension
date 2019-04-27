using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionTransformation {

    private Transform player;
    private float distanceIn2D;
    private float heightOffset;

    private Transform camera;
    private Vector3 oriRotate;
    private Vector3 oriRelativePos;
    private float inter;
    private bool is3D;

    public DimensionTransformation(Transform player,float distanceIn2D,float heightOffset) {
        this.player = player;
        this.distanceIn2D = distanceIn2D;
        this.heightOffset = heightOffset;

        initData();
        //设置相机正交视图下的Size，使透视视图与正交视图转换时减小视觉突变
        Camera.main.orthographicSize = Mathf.Tan(Camera.main.fieldOfView / 360 * Mathf.PI) * distanceIn2D;        
    }

    //初始化数据
    private void initData() {
        is3D = Config.IS_3D;
        camera = Camera.main.transform;
        inter = 1;
        oriRotate = camera.eulerAngles;
        oriRelativePos = camera.position - player.position;
    }

    //脚本中需要同步调用
    public void Update() {
        is3D = Config.IS_3D;

        //插值改变摄像机位置和朝向
        camera.eulerAngles = Vector3.Lerp(oriRotate, new Vector3(0, 0, 0), inter);
        Vector3 pos = player.position;
        pos.z -= distanceIn2D;
        pos.y += heightOffset;
        camera.position = Vector3.Lerp(player.position + oriRelativePos, pos, inter);

        if (!is3D) {
            if (inter <= 1.0f)
                inter += Time.deltaTime;
            else {
                inter = 1.0f;
                Camera.main.orthographic = !Config.IS_3D;
            }
        } else {
            Camera.main.orthographic = !Config.IS_3D;
            if (inter >= 0f)
                inter -= Time.deltaTime;
            else {
                inter = 0f;
            }
        }
    }
}
