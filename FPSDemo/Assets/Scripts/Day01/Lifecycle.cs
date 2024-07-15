using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 脚本生命周期/必然事件/消息 Message
/// <summary>
public class Lifecycle : MonoBehaviour
{
    //脚本：.cs的文本文件   类文件
    //         附加到游戏物体中，定义游戏对象行为指令的代码

    //c#逻辑类按照以下模板：
    //字段
    //属性
    //构造函数
    //方法

    //脚本类按照以下模板：
    //字段
    //方法

    //序列化字段 作用：在编辑器中显示私有变量
    [SerializeField]
    //private int a = 100;

    //作用：在编辑器中隐藏字段
    [HideInInspector]
    public float b;

    //作用：给字段定义范围
    [Range(0,100)]
    public int c;

    //习惯不写属性和构造函数，因为在编辑器里显示不出来
   // public int A
    //{
        //get { return this.a; }
        //set { this.a = value; }
    //}

    public Lifecycle()
    {
        //Debug.Log("构造函数");
        //不要在脚本中写构造函数
        //不能在子线程中访问主线程成员
        //b = Time.time;
    }

    //***********初始阶段************//
    //执行时机：创建游戏对象 --> 立即执行(早于Start)
    //作用：初始化 可以判断当满足某种条件执行此脚本 this.enable = true
    private void Awake()
    {
        //Debug.Log("Awake--" + Time.time+"--"+this.name);
    }
    //执行时机：创建游戏对象 --> 脚本启用才执行 --> 一次
    //作用：初始化
    private void Start()
    {
        //调试Debug.Log(变量)或者print(变量)
        //区别
        int a = 1;
        int b = 2;
        int c = a + b;
        //调试过程中输入代码：
        //右键--快速监视
        //查看“即时窗口”

        Debug.Log("Start--" + Time.time + "--" + this.name);
        print("ok");
    }
    //执行时机：每当脚本对象启用时
    private void OnEnable()
    {
        //Debug.Log("OnEnable--" + Time.time + "--" + this.name);
    }

    //***********物理阶段************//
    //执行时机：每隔固定时间执行1次
    //时间可以修改但不建议修改
    //设置更新频率："Edit" --> "Project Setting --> "TIme" --> "Fixed Timestep" 默认0.02s
    //适用性：适和对游戏对象做物理操作，例如移动旋转，不会受到渲染影响
    private void FixedUpdate()//固定更新
    {//渲染时间不固定(每帧渲染物体量不同、电脑性能不同)
        //Debug.Log(Time.time);
    }


    //***********输入事件阶段************//
    private void OnMouseEnter()//移入
    {

    }

    private void OnMouseOver()//经过
    {

    }

    private void OnMouseExit()//离开
    {

    }

    private void OnMouseDown()//按下
    {
        Debug.Log("OnMouseDown");
    }

    private void OnMouseUp()//抬起
    {

    }

    public float time;
    //***********游戏阶段************//
    //执行时机：渲染帧执行，执行间隔不固定
    //适用性：处理游戏逻辑
    private void Update()
    {
        int a = 1;
        int b = 2;
        int c = a + b;
        //调试也可以在update里进行
        //适合单帧调试
        //vs调试-->unity运行-->unity暂停-->vs加断点-->unity单帧运行-->结束vs调试
        time = Time.time;
    }
    //执行时机：在Update调用后执行(与Update同一帧执行)
    //适用性：跟随逻辑
    //例如移动(Update)+摄像机(LateUpdate)
    private void LateUpdate()
    {
        
    }


    //***********场景渲染阶段************//
    //执行时机：当Mesh Renderer在任何相机上可见时那一帧调用
    private void OnBecameVisible()
    {

    }

    //执行时机：当Mesh Renderer在任何相机上都不可见时那一帧调用
    private void OnBecameInvisible()
    {

    }


    //***********结束阶段************//
    //执行时机：对象变为不可用或附属游戏对象非激活状态时调用此函数
    private void OnDisable()
    {

    }
    //执行时机：当脚本销毁或附属的游戏对象被销毁时被调用
    private void OnDestroy()
    {

    }
    //执行时机：当应用程序退出时被调用
    private void OnApplicationQuit()
    {

    }


}

