using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController cc;//CharacterController���g�����߂̕ϐ�
    private Vector3 velocity;//CharacterController�ɏd�͂������邽�߂̕ϐ�

    public float jumpPower = 8;//�W�����v��
    public float moveSpeed = 10;//�ړ��X�s�[�h

    public float sensitivityX = 15F;//�}�E�X�̉��̓����̋���
    public float sensitivityY = 15F;//�}�E�X�̏c�̓����̋���

    public float minimumX = -360F;//���̉�]�̍Œ�l
    public float maximumX = 360F; //���̉�]�̍ő�l

    public float minimumY = -60F;//�c�̉�]�̍Œ�l
    public float maximumY = 60F;//�c�̉�]�̍ő�l

    public float rotationX = 0f;//�����̉�]��
    public float rotationY = 0f;//�c���̉�]��

    public GameObject verRot;//�c��]������I�u�W�F�N�g(�J����)
    public GameObject horRot;//����]������I�u�W�F�N�g(�v���C���[)

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();//CharacterContoller�̒l���擾����cc�ɑ��
    }

    // Update is called once per frame
    void Update()
    {
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") *sensitivityX;//rotationX�����݂�y�̌�����X�̈ړ���*sensitivityX�̕�������]������


        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;//rotationY��-60~60�̒l�ɂ���

        verRot.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);//�I�u�W�F�N�g�̌�����new Vecter3(-rotationY,rotationX,0)�ɂ���

        horRot.transform.localEulerAngles = new Vector3(0, rotationX, 0);//�I�u�W�F�N�g�̌�����newVector3(-rotationY,rotationX,0�ɂ���
        

        if(Input.GetKey(KeyCode.W))//����w�L�[�������ꂽ��
        {
            cc.Move(this.gameObject.transform.forward * moveSpeed * Time.deltaTime);//�O���ɓ�����
        }

        if(Input.GetKey(KeyCode.A))//����A�L�[�������ꂽ��
        {
            cc.Move(this.gameObject.transform.right * -1 * moveSpeed * Time.deltaTime);//���ɓ�����
        }

        if(Input.GetKey(KeyCode.D)) //����D�L�[�������ꂽ��
        {
            cc.Move(this.gameObject.transform.right * moveSpeed * Time.deltaTime);//�E�ɓ�����
        }

        cc.Move(velocity * Time.deltaTime);//cc�����celocity��������


        velocity.y += Physics.gravity.y * Time.deltaTime;// velocity,y�ɂ͏d�͕�����������
        if(cc.isGrounded)//�����n�ʂɂ��Ă�����A
        {
            if(Input.GetKey(KeyCode.Space))//�����X�y�[�X�L�[�������ꂽ��
            {
                velocity.y = jumpPower;//�W�����v����
            }
        }



    }
}
