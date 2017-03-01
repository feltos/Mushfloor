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
    float HeavyBulletCooldown = 0.2f;
    float HeavyBulletShoot = 0.2f;
    float HeavyBulletremaining = 5f;
    float FireCircleRamaining = 3f;
    [SerializeField]
    Transform BulletPrefab;
    [SerializeField]
    Transform HeavyBulletPrefab;
    bool StopToShoot = false;

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
                    for (int j = 0; j <= FireCircleRamaining; j++)
                    {
                        if (FireCircleCooldown >= FireCircleShoot)
                        {
                            for (int l = 0; l <= 36; l++)
                            {
                                FireCircle(Quaternion.AngleAxis(l * 10, new Vector3(0, 0, 1)) * DirectionOfShoot.normalized);
                            }
                        }                        
                    }
                    StopToShoot = false;
                    AttackCooldown = 0f;
                }
                break;

            case AttackListBoss.FIRE2:
                {
                    for (int i = 0; i <= HeavyBulletremaining; i++)
                    {
                        if (HeavyBulletCooldown >= HeavyBulletShoot)
                        {
                            FireHeavyBullet();
                        }                                                                                               
                    }
                    AttackCooldown = 0f;
                    StopToShoot = false;
                }
                break;
        }
    }

	void Update ()
    {
        FireCircleCooldown += Time.deltaTime;
        HeavyBulletCooldown += Time.deltaTime;
        AttackCooldown += Time.deltaTime;
        DirectionOfShoot = Target.transform.position - transform.position;

        if (AttackCooldown >= AttackShoot && !StopToShoot)
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
                StopToShoot = true;                     
        
        
                   
    }

    void FireHeavyBullet()
    {                          
            
            
                var shotTransform = Instantiate(HeavyBulletPrefab, transform.position, transform.rotation) as Transform;
                shotTransform.position = transform.position;
                ShotBasic shot = shotTransform.gameObject.GetComponent<ShotBasic>();


                shot.isEnemyShot = true;
                shot.Direction = DirectionOfShoot.normalized;
                HeavyBulletCooldown = 0f;
                StopToShoot = true;
                   
      
    }
}
