using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    Vector2 DirectionOfShoot;
    float AttackCooldown = 2f;
    float AttackShoot = 2f;
    float FireCircleCooldown = 2f;
    float FireCircleShoot = 2f;
    float HeavyBulletCooldown = 0.5f;
    float HeavyBulletShoot = 0.5f;
    float HeavyBulletremaining = 4f;
    float FireCircleremaining = 2f;
    float TornadoFireRemaining = 1;
    float TornadoShoot = 0.05f;
    float TornadoCooldown = 0.05f;
    [SerializeField]
    Transform BulletPrefab;
    [SerializeField]
    Transform HeavyBulletPrefab;
    bool StopToShoot = true;

    bool canRandom = true;

    [SerializeField]
    float HP;
    bool IsEnemy = true;
    [SerializeField]
    Slider HealthSlider;

    int attackListBossLenght = AttackListBoss.GetNames(typeof(AttackListBoss)).Length;

    enum AttackListBoss
    {
        CircleFire,
        HeavyBulletFire,
        Tornadofire
    }
    AttackListBoss AttackList;

    void Awake()
    {
        Target = GameObject.Find("Player");
    }

    void Start()
    {
        FireCircleCooldown = 0f;
        HeavyBulletCooldown = 0f;
        TornadoCooldown = 0f;
        AttackList = AttackListBoss.CircleFire;
    }


    void DoAttack()
    {
        switch (AttackList)
        {
            case AttackListBoss.CircleFire:
                {
                                
                    if (FireCircleremaining >= 0)
                        {                                                      
                            if (FireCircleCooldown >= FireCircleShoot)
                            {
                                for (int l = 0; l <= 36; l++)
                                {
                                    FireCircle(Quaternion.AngleAxis(l * 10, new Vector3(0, 0, 1)) * DirectionOfShoot.normalized);
                                    FireCircleCooldown = 0;
                                }
                            FireCircleremaining -= 1;
                            
                            
                        }                                                                                                                  
                        }                                       
                    AttackCooldown = 0f;
                    if(FireCircleremaining <= 0)
                    {
                        StopToShoot = false;
                    }                    
                }
                break;

            case AttackListBoss.Tornadofire:
                {
                    if(TornadoFireRemaining >= 0) 
                        {
                        Debug.Log(TornadoFireRemaining);
                        if (TornadoCooldown >= TornadoShoot)
                        {
                                for (int i = 0; i <= 72; i++)
                                {
                                TornadoFire(Quaternion.AngleAxis(i * 10, new Vector3(0, 0, 1)) * DirectionOfShoot.normalized);
                                TornadoCooldown = 0;
                            }                          
                        }
                        TornadoFireRemaining -= 1;
                    }
                    AttackCooldown = 0f;
                    if(TornadoFireRemaining >= 0)
                    {
                        StopToShoot = false;
                    }
                }
                break;

            case AttackListBoss.HeavyBulletFire:
                {
                   
                    if(HeavyBulletremaining >= 0)
                    {
                        if(HeavyBulletCooldown >= HeavyBulletShoot)
                        {
                            FireHeavyBullet();
                            HeavyBulletremaining -= 1;
                            HeavyBulletCooldown = 0;
                           
                        }

                    }   
                    AttackCooldown = 0f;
                    if(HeavyBulletremaining <= 0)
                    {
                        StopToShoot = false;
                    }
                }
                break;
        }
    }

    void Update()
    {
        FireCircleCooldown += Time.deltaTime;
        HeavyBulletCooldown += Time.deltaTime;
        TornadoCooldown += Time.deltaTime;
        DirectionOfShoot = Target.transform.position - transform.position;

        if (!StopToShoot)
        {
            AttackCooldown += Time.deltaTime;
        }  
             
        if (AttackCooldown >= AttackShoot && !StopToShoot)
        {
            AttackList = (AttackListBoss)Random.Range(0, attackListBossLenght);
            
            switch (AttackList)
            {
                case AttackListBoss.CircleFire:
                FireCircleremaining = 2;
                    break;
                case AttackListBoss.HeavyBulletFire:
                    HeavyBulletremaining = 4;
                    break;
                case AttackListBoss.Tornadofire:
                    TornadoFireRemaining = 1;
                    break;
            }
            StopToShoot = true;
        }
        if (StopToShoot)
        {
            AttackCooldown = 0f;
            DoAttack();
        }


    }

    void FireCircle(Vector2 direction)
    {
       
        
            var shotTransform = Instantiate(BulletPrefab, transform.position, transform.rotation) as Transform;
            shotTransform.position = transform.position;
            BulletBasic shot = shotTransform.gameObject.GetComponent<BulletBasic>();


            shot.isEnemyShot = true;
            shot.Direction = direction.normalized;
            FireCircleCooldown = 0f;
        
           
    }

    void FireHeavyBullet()
    {
        
        
            var shotTransform = Instantiate(HeavyBulletPrefab, transform.position, transform.rotation) as Transform;
            shotTransform.position = transform.position;
            BulletBasic shot = shotTransform.gameObject.GetComponent<BulletBasic>();


            shot.isEnemyShot = true;
            shot.Direction = DirectionOfShoot.normalized;
            HeavyBulletCooldown = 0f;
        
             
    }

    void TornadoFire(Vector2 direction)
    {


        var shotTransform = Instantiate(BulletPrefab, transform.position, transform.rotation) as Transform;
        shotTransform.position = transform.position;
        BulletBasic shot = shotTransform.gameObject.GetComponent<BulletBasic>();


        shot.isEnemyShot = true;
        shot.Direction = direction.normalized;
        FireCircleCooldown = 0f;


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        BulletBasic shot = collision.gameObject.GetComponent<BulletBasic>();
        if (shot != null)
        {
            if (shot.isEnemyShot != IsEnemy)
            {
                HP -= shot.damage;
                Destroy(shot.gameObject);
                HealthSlider.value = HP;
            }

            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("AOE"))
        {
            HP -= 1;
        }
    }

}
