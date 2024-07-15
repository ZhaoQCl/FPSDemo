using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ű���������/��Ȼ�¼�/��Ϣ Message
/// <summary>
public class Lifecycle : MonoBehaviour
{
    //�ű���.cs���ı��ļ�   ���ļ�
    //         ���ӵ���Ϸ�����У�������Ϸ������Ϊָ��Ĵ���

    //c#�߼��ఴ������ģ�壺
    //�ֶ�
    //����
    //���캯��
    //����

    //�ű��ఴ������ģ�壺
    //�ֶ�
    //����

    //���л��ֶ� ���ã��ڱ༭������ʾ˽�б���
    [SerializeField]
    //private int a = 100;

    //���ã��ڱ༭���������ֶ�
    [HideInInspector]
    public float b;

    //���ã����ֶζ��巶Χ
    [Range(0,100)]
    public int c;

    //ϰ�߲�д���Ժ͹��캯������Ϊ�ڱ༭������ʾ������
   // public int A
    //{
        //get { return this.a; }
        //set { this.a = value; }
    //}

    public Lifecycle()
    {
        //Debug.Log("���캯��");
        //��Ҫ�ڽű���д���캯��
        //���������߳��з������̳߳�Ա
        //b = Time.time;
    }

    //***********��ʼ�׶�************//
    //ִ��ʱ����������Ϸ���� --> ����ִ��(����Start)
    //���ã���ʼ�� �����жϵ�����ĳ������ִ�д˽ű� this.enable = true
    private void Awake()
    {
        //Debug.Log("Awake--" + Time.time+"--"+this.name);
    }
    //ִ��ʱ����������Ϸ���� --> �ű����ò�ִ�� --> һ��
    //���ã���ʼ��
    private void Start()
    {
        //����Debug.Log(����)����print(����)
        //����
        int a = 1;
        int b = 2;
        int c = a + b;
        //���Թ�����������룺
        //�Ҽ�--���ټ���
        //�鿴����ʱ���ڡ�

        Debug.Log("Start--" + Time.time + "--" + this.name);
        print("ok");
    }
    //ִ��ʱ����ÿ���ű���������ʱ
    private void OnEnable()
    {
        //Debug.Log("OnEnable--" + Time.time + "--" + this.name);
    }

    //***********����׶�************//
    //ִ��ʱ����ÿ���̶�ʱ��ִ��1��
    //ʱ������޸ĵ��������޸�
    //���ø���Ƶ�ʣ�"Edit" --> "Project Setting --> "TIme" --> "Fixed Timestep" Ĭ��0.02s
    //�����ԣ��ʺͶ���Ϸ��������������������ƶ���ת�������ܵ���ȾӰ��
    private void FixedUpdate()//�̶�����
    {//��Ⱦʱ�䲻�̶�(ÿ֡��Ⱦ��������ͬ���������ܲ�ͬ)
        //Debug.Log(Time.time);
    }


    //***********�����¼��׶�************//
    private void OnMouseEnter()//����
    {

    }

    private void OnMouseOver()//����
    {

    }

    private void OnMouseExit()//�뿪
    {

    }

    private void OnMouseDown()//����
    {
        Debug.Log("OnMouseDown");
    }

    private void OnMouseUp()//̧��
    {

    }

    public float time;
    //***********��Ϸ�׶�************//
    //ִ��ʱ������Ⱦִ֡�У�ִ�м�����̶�
    //�����ԣ�������Ϸ�߼�
    private void Update()
    {
        int a = 1;
        int b = 2;
        int c = a + b;
        //����Ҳ������update�����
        //�ʺϵ�֡����
        //vs����-->unity����-->unity��ͣ-->vs�Ӷϵ�-->unity��֡����-->����vs����
        time = Time.time;
    }
    //ִ��ʱ������Update���ú�ִ��(��Updateͬһִ֡��)
    //�����ԣ������߼�
    //�����ƶ�(Update)+�����(LateUpdate)
    private void LateUpdate()
    {
        
    }


    //***********������Ⱦ�׶�************//
    //ִ��ʱ������Mesh Renderer���κ�����Ͽɼ�ʱ��һ֡����
    private void OnBecameVisible()
    {

    }

    //ִ��ʱ������Mesh Renderer���κ�����϶����ɼ�ʱ��һ֡����
    private void OnBecameInvisible()
    {

    }


    //***********�����׶�************//
    //ִ��ʱ���������Ϊ�����û�����Ϸ����Ǽ���״̬ʱ���ô˺���
    private void OnDisable()
    {

    }
    //ִ��ʱ�������ű����ٻ�������Ϸ��������ʱ������
    private void OnDestroy()
    {

    }
    //ִ��ʱ������Ӧ�ó����˳�ʱ������
    private void OnApplicationQuit()
    {

    }


}

