using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    protected float HP = 10;

    [SerializeField]
    GameObject TargetObject;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    int MaxCount = -200;

    [SerializeField]
    float bulletSpeed = 10f;

    protected int timeCount;
    protected float maxHP;
   
    private void Start()
    {
        maxHP = HP;
        timeCount = 0;
    }
    void FixedUpdate()
    {
        if (HP > 0)
            timeCount++;

        if(timeCount >= MaxCount)
        {
            timeCount = 0;
            EnemyShot();
        }       
    }
    // Update is called once per frame
    void EnemyShot()
    {
        int BulletCount = 5;

        for (int i = 0; i < BulletCount; i++)
        {
            GameObject Newbullet = Instantiate(bullet, this.transform.position + Vector3.up, Quaternion.identity);
            Rigidbody bulletRB = Newbullet.GetComponent<Rigidbody>();
            ShotRandom(Newbullet, bulletRB);         
        }

        for (int i = 0; i < BulletCount-2; i++)
        {
            GameObject Newbullet = Instantiate(bullet, this.transform.position + Vector3.up, Quaternion.identity);
            Rigidbody bulletRB = Newbullet.GetComponent<Rigidbody>();
            ShotPlayer(Newbullet, bulletRB);
        }
    }

    void ShotPlayer(GameObject _bullet, Rigidbody _rigidbody)
    {
        // ターゲットの方向を向く
        Vector3 targetDirection = (TargetObject.transform.position - _bullet.transform.position).normalized;

        // Y 軸のランダム回転を適用
        Quaternion randomYRotation = Quaternion.Euler(0f, UnityEngine.Random.Range(-30f, 30f), 0f);
        Quaternion finalRotation = Quaternion.LookRotation(targetDirection) * randomYRotation;

        // 回転を適用
        _bullet.transform.rotation = finalRotation;

        // 力を加えて発射
        _rigidbody.AddForce(_bullet.transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }
    void ShotRandom(GameObject _bullet, Rigidbody _rigidbody)
    {
        float randomYRotation = UnityEngine.Random.Range(0f, 360f);
        _bullet.transform.rotation = Quaternion.Euler(0f, randomYRotation, 0f);

        _rigidbody.AddForce(_bullet.transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }
}
