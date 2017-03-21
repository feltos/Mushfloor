﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    
    [SerializeField]
    Vector2 BasicSpeed;
    [SerializeField]
    Vector2 DashSpeed;
    [SerializeField]
    Vector2 ActualSpeed;
    private Vector2 Movement;
    float horizontal;
    float vertical;
    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    bool IsTurnedRight = true;
    Vector2 direction;
    const float WalkDeadZone = 0.01f;
    float timeBetweenShoot = 0.25f;
    float PeriodBetweenShoot = 0.25f;
    [SerializeField]
    Transform BulletPrefab;
    [SerializeField]float BulletLeft;
    float EmptyGun = 0;
    [SerializeField]
    float ReloadTime = 1f;
    float DashReload = 0.3f;
    float PeriodBetweenDash = 0.3f;
    [SerializeField]
    float HP;
    float TimeBetweenDamage = 2f;
    float PeriodBetweenDamage = 2f;
    bool IsEnemy = true;
    [SerializeField]
    BoxCollider2D BoxC2D;

    bool ImmuneToTraps = false;
    [SerializeField]
    GameObject AntiTraps;

    float BasicKeyHold = 0;
    bool BossKeyHold = false;
    float GrowTime = 0f;
    float GrowCooldown = 1.5f;
    Vector3 DefaultScale = new Vector3(0.2f, 0.2f, 0.2f);
    Vector3 NewScale = new Vector3(0.01f, 0.01f, 0.01f);
    GameObject PositionbeforeFall;
    bool Fall = false;

    [SerializeField]GameManager gameManager;

    public
    List<GameObject> GunsOwned = new List<GameObject>();


    [SerializeField]GameObject[] GunsPrefab;
    [SerializeField]Transform AK_47Bullets;
    float AK_47BulletsRemaining = 8;
    [SerializeField]GameObject Hand;
    
    public enum Guns
    {
        BasicGun,
        Shotgun,
        AK_47,
        Sniper,
        Length
    }
    Guns CurrentGun = Guns.BasicGun;



    void Awake()
    {
        Cursor.visible = true;
    }

    void Start ()
    {
        ActualSpeed = BasicSpeed;
        CurrentGun = Guns.BasicGun;
	}
	
	
	void Update ()
    {
        
        timeBetweenShoot += Time.deltaTime;
        DashReload += Time.deltaTime;
        TimeBetweenDamage += Time.deltaTime;
        ////////////////WALK//////////////////
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Movement = new Vector2(
        ActualSpeed.x * horizontal,
        ActualSpeed.y * vertical);
        /////////////////////////////////////

        //////////////FLIP/////////////////
        if(horizontal > 0 && !IsTurnedRight)
        {
            Flip();
        }
        if(horizontal < 0 && IsTurnedRight)
        {
            Flip();
        }
        ///////////////////////////////////

        ////////////FIRE////////////////
        Fire(false);
        //////////CHANGE WEAPON/////////////
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            foreach(var g in GunsOwned)
            {
                g.SetActive(false);
            }
            for(int i = 0; i < GunsOwned.Count;i++)
            {
                GunsOwned[i].SetActive(true);
            }
        }
        
        
        /////////////RELOAD////////////
        Reload();
        ///////////////////////////////

        ////////////////DASH///////////
        Dash();
        //////////////////////////////

        //////////////FALL IN A HOLE/////////////
        if(Fall)
        {
            FallInHole();
        }
        //////////////DIE/////////////////////
        if (HP <= 0)
        {
            SceneManager.LoadScene(1);
        }

    }

     void FixedUpdate()
    {        
        if(!Fall)
        {
            rb2d.velocity = Movement;
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        IsTurnedRight = !IsTurnedRight;
    }

    void Fire(bool isEnemy)
    {
        var inputDevice = (InputManager.Devices.Count > 0) ? InputManager.Devices[0] : null;

        if (inputDevice != null && timeBetweenShoot > PeriodBetweenShoot &&
            (Mathf.Abs(inputDevice.RightStick.X) > WalkDeadZone || Mathf.Abs(inputDevice.RightStick.Y) > WalkDeadZone)
            && InputManager.Devices[0].RightBumper.WasPressed && BulletLeft > EmptyGun)
        {
            direction = new Vector3(inputDevice.RightStick.X, inputDevice.RightStick.Y);
            timeBetweenShoot = 0;
            BulletLeft -= 1;

        }
        else if (Input.GetMouseButtonDown(0) && timeBetweenShoot > PeriodBetweenShoot && BulletLeft > EmptyGun)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            direction = mousePosition - transform.position;
            timeBetweenShoot = 0;
            BulletLeft -= 1;
        }
        else
        {
            return;
        }

        switch(CurrentGun)
        {
            case Guns.BasicGun:
                var BasicBullet = Instantiate(BulletPrefab, transform.position, transform.rotation) as Transform;
                BasicBullet.position = transform.position;
                BulletBasic BasicShot = BasicBullet.gameObject.GetComponent<BulletBasic>();
                if (BasicShot != null)
                {
                    BasicShot.isEnemyShot = isEnemy;
                    BasicShot.Direction = direction.normalized;
                }
                break;
            case Guns.Shotgun:
                for(int i = -2; i <= 2;i++)
                {
                    var ShotgunBullet = Instantiate(BulletPrefab, transform.position, transform.rotation)as Transform;
                    ShotgunBullet.position = transform.position;
                    BulletBasic ShotgunShot = ShotgunBullet.gameObject.GetComponent<BulletBasic>();                                     
                    if (ShotgunShot != null)
                    {
                        ShotgunShot.isEnemyShot = isEnemy;
                        ShotgunShot.Direction = (Quaternion.AngleAxis(i * 10, new Vector3(0, 0, 1)) * direction).normalized;
                    }
                }
                break;
            case Guns.AK_47:              
                InvokeRepeating("AK_47Fire", 0f, 0.1f);                                              
                break;
            case Guns.Sniper:
                for(int i = 0; i <= 5; i++)
                {
                    var SniperBullet = Instantiate(BulletPrefab, transform.position, transform.rotation)as Transform;
                    SniperBullet.position = transform.position;
                    BulletBasic SniperShot = SniperBullet.gameObject.GetComponent<BulletBasic>();
                    if(SniperShot != null)
                    {
                        SniperShot.isEnemyShot = isEnemy;
                        SniperShot.Direction = direction.normalized;
                    }
                }
                break;                         
        }
       
    }

    void Reload()
    {
        if(BulletLeft <= EmptyGun)
        {
            ReloadTime -= Time.deltaTime;
        }
        if(ReloadTime <= 0 && BulletLeft <= EmptyGun)
        {
            BulletLeft = 10;
            ReloadTime = 1f;
        }
    }
    void Dash()
    {
        var inputDevice = (InputManager.Devices.Count > 0) ? InputManager.Devices[0] : null;

        if ((inputDevice != null && InputManager.Devices[0].Action2.WasPressed && DashReload > PeriodBetweenDash) || (Input.GetMouseButtonDown(1) && DashReload > PeriodBetweenDash))
        {
            ActualSpeed = DashSpeed;
            DashReload = 0f;
            BoxC2D.enabled = false;
        }
        if (DashReload > PeriodBetweenDash)
        {
            ActualSpeed = BasicSpeed;
            BoxC2D.enabled = true;
        }
    }
  

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") && TimeBetweenDamage >= PeriodBetweenDamage)
        {
            HP -= 1;
            TimeBetweenDamage = 0;
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        BulletBasic shot = collision.gameObject.GetComponent<BulletBasic>();
        if (shot != null)
        {
            if (shot.isEnemyShot == IsEnemy && TimeBetweenDamage >= PeriodBetweenDamage)
            {
                HP -= shot.damage;
                Destroy(shot.gameObject);
                TimeBetweenDamage = 0;
            }

        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("AOE"))
        {
            if (!ImmuneToTraps)
            {
                HP -= 1;
            }
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("AntiTraps"))
        {
            ImmuneToTraps = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Hearth"))
        {
            HP += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("BasicKey"))
        {
            BasicKeyHold += 1f;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("BossKey"))
        {
            BossKeyHold = true;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Shotgun"))
        {
            foreach(var g in GunsOwned)
            {
                g.SetActive(false);
                
            }
            var Shotgun = Instantiate(GunsPrefab[0], Hand.transform.position, Hand.transform.rotation);
            Shotgun.transform.parent = transform;
            GunsOwned.Add(Shotgun.gameObject);
            CurrentGun = Guns.Shotgun;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("AK_47"))
        {
            foreach(var g in GunsOwned)
            {
                g.SetActive(false);
            }
            var AK_47 = Instantiate(GunsPrefab[1], Hand.transform.position, Hand.transform.rotation);
            AK_47.transform.parent = transform;
            GunsOwned.Add(AK_47.gameObject);
            CurrentGun = Guns.AK_47;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Sniper"))
        {
            foreach(var g in GunsOwned)
            {
                g.SetActive(false);
            }
            var Sniper = Instantiate(GunsPrefab[2], Hand.transform.position, Hand.transform.rotation);
            Sniper.transform.parent = transform;
            GunsOwned.Add(Sniper.gameObject);
            CurrentGun = Guns.Sniper;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("DungeonDoor"))
        {
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Door1"))
        {
            if(gameManager.SwitchArea == GameManager.SwitchRoom.DEFAULT)
            {
                gameManager.SwitchArea = GameManager.SwitchRoom.ROOM2;
                gameManager.CheckRoom();           
            }
            else
            {
                gameManager.SwitchArea = GameManager.SwitchRoom.DEFAULT;
                gameManager.CheckRoom();
            }
                                                                                                                 
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Door2"))
        {
            if(gameManager.SwitchArea == GameManager.SwitchRoom.DEFAULT)
            {
                gameManager.SwitchArea = GameManager.SwitchRoom.ROOM3;
                gameManager.CheckRoom();
            }
            else
            {
                gameManager.SwitchArea = GameManager.SwitchRoom.DEFAULT;
                gameManager.CheckRoom();
            }
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Hole"))
        {
            PositionbeforeFall = collision.gameObject.transform.FindChild("PositionBeforeFall").gameObject;
            Fall = true;                         
        }
    }

    public float GetKeyHold()
    {
        return BasicKeyHold;
    }

    public void SetKeyHold()
    {
        BasicKeyHold -= 1;
    }

    void FallInHole()
    {
        rb2d.velocity = Vector3.zero;
        GrowTime += Time.deltaTime;
        if (GrowTime >= GrowCooldown)
        {
            transform.localScale -= NewScale;
        }
        if (transform.localScale.x <= 0)
        {
            transform.position = PositionbeforeFall.transform.position;
            transform.localScale = DefaultScale;
            GrowTime = 0;
            HP -= 1;
            Fall = false;
        }
    }

    void AK_47Fire()
    {
        var AK_47Bullet = Instantiate(AK_47Bullets, transform.position, transform.rotation);
        AK_47Bullet.position = transform.position;
        BulletBasic AK_47Shot = AK_47Bullet.gameObject.GetComponent<BulletBasic>();
        if (AK_47Shot != null)
        {
            AK_47Shot.isEnemyShot = false;
            AK_47Shot.Direction = (Quaternion.AngleAxis(Random.Range(-10, 10), new Vector3(0, 0, 1)) * direction).normalized;
        }
        AK_47BulletsRemaining -= 1;
        if (AK_47BulletsRemaining <= 0)
        {
            CancelInvoke("AK_47Fire");
            AK_47BulletsRemaining = 8;
        }
        
    }

}
