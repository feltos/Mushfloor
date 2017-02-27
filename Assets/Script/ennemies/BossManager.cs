using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    Vector2 DirectionOfShoot;
    float ShootCooldown = 1.5f;
    float BulletShoot = 1.5f;
    [SerializeField]
    Transform BulletPrefab;

    void Awake()
    {
        Target = GameObject.Find("Player");
    }

    void Start ()
    {
        ShootCooldown = 0f;
	}
	
	
	void Update ()
    {
        ShootCooldown += Time.deltaTime;
        DirectionOfShoot = Target.transform.position - transform.position;
        if(ShootCooldown >= BulletShoot)
        {
            for (int i = 0; i <= 35; i++)
            {
                fire(Quaternion.AngleAxis(i * 10, new Vector3(0, 0, 1)) * DirectionOfShoot.normalized);
            }
        }
     
    }

    void fire(Vector2 direction)
    {

        var shotTransform = Instantiate(BulletPrefab, transform.position, transform.rotation) as Transform;
        shotTransform.position = transform.position;
        ShotBasic shot = shotTransform.gameObject.GetComponent<ShotBasic>();


        shot.isEnemyShot = true;
        shot.Direction = direction.normalized;
        ShootCooldown = 0f;   
    }
}
