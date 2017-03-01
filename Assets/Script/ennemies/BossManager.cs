using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    Vector2 DirectionOfShoot;
    float AttackCooldown = 2f;
    float AttackShoot = 2f;
    float FireCircleCooldown = 2f;
    float FireCircleShoot = 2f;
    float HeavyBulletCooldown = 1f;
    float HeavyBulletShoot = 1f;
    float HeavyBulletremaining = 4f;
    float FireCircleremaining = 2f;
    [SerializeField]
    Transform BulletPrefab;
    [SerializeField]
    Transform HeavyBulletPrefab;
    bool StopToShoot = false;

    bool canRandom = true;

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

    void Start()
    {
        
        HeavyBulletCooldown = 0f;
        AttackList = AttackListBoss.FIRE1;
    }


    void checkAttack()
    {
        switch (AttackList)
        {
            case AttackListBoss.FIRE1:
                {
                        while(FireCircleCooldown >= FireCircleShoot && FireCircleremaining >= 0)
                        {
                            for (int l = 0; l <= 36; l++)
                            {
                                FireCircleremaining -= 1;
                                FireCircle(Quaternion.AngleAxis(l * 10, new Vector3(0, 0, 1)) * DirectionOfShoot.normalized);
                                StopToShoot = true;
                            }                      
                        }
                    FireCircleremaining = 3;
                    canRandom = true;                    
                    AttackCooldown = 0f;
                    StopToShoot = false;
                }
                break;

            case AttackListBoss.FIRE2:
                {                    
                        while (HeavyBulletCooldown >= HeavyBulletShoot && HeavyBulletremaining >= 0)
                        {
                            HeavyBulletremaining -= 1;
                            FireHeavyBullet();
                            StopToShoot = true;
                        }   
                    HeavyBulletremaining = 5;                
                    canRandom = true;
                    AttackCooldown = 0f;
                    StopToShoot = false;
                }
                break;
        }
    }

    void Update()
    {
        FireCircleCooldown += Time.deltaTime;
        HeavyBulletCooldown += Time.deltaTime;
        DirectionOfShoot = Target.transform.position - transform.position;

        if (!StopToShoot)
        {
            AttackCooldown += Time.deltaTime;
        }  
             
        if (canRandom && AttackCooldown >= AttackShoot && !StopToShoot)
        {
            AttackList = (AttackListBoss)Random.Range(0, attackListBossLenght);
            canRandom = false;
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
        HeavyBulletCooldown = 0f;        
    }
}
