using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    Vector2 DirectionOfShoot;
    float AttackCooldown = 2f;
    float AttackShoot = 2f;
    float FireCircleCooldown = 2f;
    float FireCircleShoot = 2f;
    float HeavyBulletCooldown = 3f;
    float HeavyBulletShoot = 3f;
    float HeavyBulletremaining = 5f;
    float FireCircleRamaining = 3f;
    [SerializeField]
    Transform BulletPrefab;
    [SerializeField]
    Transform HeavyBulletPrefab;

    int attackListBossLenght = AttackListBoss.GetNames(typeof(AttackListBoss)).Length;

    enum AttackListBoss
    {
        FIRE1,
        FIRE2
    }
    AttackListBoss AttackList;

    void Awake()
    {
        Target = GameObject.Find("Player");
    }

    void Start ()
    {
        FireCircleCooldown = 0f;
        HeavyBulletCooldown = 0f;
        AttackList = AttackListBoss.FIRE1;
	}


    void checkAttack()
    {
        switch (AttackList)
        {
            case AttackListBoss.FIRE1:
                {
                    FireCircle(DirectionOfShoot);
                }
                break;

            case AttackListBoss.FIRE2:
                {
                    FireHeavyBullet();
                }
                break;
        }
    }

	void Update ()
    {
        FireCircleCooldown += Time.deltaTime;
        HeavyBulletCooldown += Time.deltaTime;
        DirectionOfShoot = Target.transform.position - transform.position;

        if (AttackCooldown >= AttackShoot)
        {
            AttackList = (AttackListBoss)Random.Range(0, attackListBossLenght);
            checkAttack();
        }
        
    }

    void FireCircle(Vector2 direction)
    {
        
        
            var shotTransform = Instantiate(BulletPrefab, transform.position, transform.rotation) as Transform;
            shotTransform.position = transform.position;
            ShotBasic shot = shotTransform.gameObject.GetComponent<ShotBasic>();


            shot.isEnemyShot = true;
            shot.Direction = direction.normalized;
            FireCircleCooldown = 0f;
        
       
    }

    void FireHeavyBullet()
    {
       
            
            var shotTransform = Instantiate(HeavyBulletPrefab, transform.position, transform.rotation) as Transform;
            shotTransform.position = transform.position;
            ShotBasic shot = shotTransform.gameObject.GetComponent<ShotBasic>();


            shot.isEnemyShot = true;
            shot.Direction = DirectionOfShoot.normalized;
            FireCircleCooldown = 0f;
        
     
    }
}
