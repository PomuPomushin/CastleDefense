using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController cc;//CharacterControllerを使うための変数
    private Vector3 velocity;//CharacterControllerに重力をかけるための変数

    public float jumpPower = 8;//ジャンプ力
    public float moveSpeed = 10;//移動スピード

    public float sensitivityX = 15F;//マウスの横の動きの強さ
    public float sensitivityY = 15F;//マウスの縦の動きの強さ

    public float minimumX = -360F;//横の回転の最低値
    public float maximumX = 360F; //横の回転の最大値

    public float minimumY = -60F;//縦の回転の最低値
    public float maximumY = 60F;//縦の回転の最大値

    public float rotationX = 0f;//横軸の回転量
    public float rotationY = 0f;//縦軸の回転量

    public GameObject verRot;//縦回転させるオブジェクト(カメラ)
    public GameObject horRot;//横回転させるオブジェクト(プレイヤー)

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();//CharacterContollerの値を取得してccに代入
    }

    // Update is called once per frame
    void Update()
    {
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") *sensitivityX;//rotationXを現在のyの向きにXの移動量*sensitivityXの分だけ回転させる


        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;//rotationYを-60~60の値にする

        verRot.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);//オブジェクトの向きをnew Vecter3(-rotationY,rotationX,0)にする

        horRot.transform.localEulerAngles = new Vector3(0, rotationX, 0);//オブジェクトの向きをnewVector3(-rotationY,rotationX,0にする
        

        if(Input.GetKey(KeyCode.W))//もしwキーが押されたら
        {
            cc.Move(this.gameObject.transform.forward * moveSpeed * Time.deltaTime);//前方に動かす
        }

        if(Input.GetKey(KeyCode.A))//もしAキーが押されたら
        {
            cc.Move(this.gameObject.transform.right * -1 * moveSpeed * Time.deltaTime);//左に動かす
        }

        if(Input.GetKey(KeyCode.D)) //もしDキーが押されたら
        {
            cc.Move(this.gameObject.transform.right * moveSpeed * Time.deltaTime);//右に動かす
        }

        cc.Move(velocity * Time.deltaTime);//ccを常にcelocity分動かす


        velocity.y += Physics.gravity.y * Time.deltaTime;// velocity,yには重力分足し続ける
        if(cc.isGrounded)//もし地面についていたら、
        {
            if(Input.GetKey(KeyCode.Space))//もしスペースキーが押されたら
            {
                velocity.y = jumpPower;//ジャンプする
            }
        }



    }
}
