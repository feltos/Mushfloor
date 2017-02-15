﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerMovements : MonoBehaviour
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


    void Awake()
    {
        Cursor.visible = true;
    }

    void Start ()
    {
        ActualSpeed = BasicSpeed;
	}
	
	
	void Update ()
    {
        timeBetweenShoot += Time.deltaTime;
        DashReload += Time.deltaTime;
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
        ////////////////////////////////

        /////////////RELOAD////////////
        Reload();
        ///////////////////////////////

        ////////////////DASH///////////
        Dash();
        //////////////////////////////
	}

     void FixedUpdate()
    {
        rb2d.velocity = Movement;
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
        var shotTransform = Instantiate(BulletPrefab,transform.position,transform.rotation) as Transform;
        shotTransform.position = transform.position;
        ShotBasic shot = shotTransform.gameObject.GetComponent<ShotBasic>();
        if(shot != null)
        {
            shot.isEnemyShot = isEnemy;
            shot.Direction = direction.normalized;
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
        }
        if (DashReload > PeriodBetweenDash)
        {
            ActualSpeed = BasicSpeed;
        }
    }
}
