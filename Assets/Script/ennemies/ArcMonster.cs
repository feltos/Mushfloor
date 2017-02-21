using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcMonster : MonoBehaviour
{

    [SerializeField]
    float HP;
    [SerializeField]
    GameObject Target;
    Vector2 Direction;
    [SerializeField]
    Vector2 Speed;
    Vector2 Movement;
    [SerializeField]
    Rigidbody2D rb2dAM;
    [SerializeField]Transform BulletPrefab;
    float ShootCooldown = 1.5f;
    float BulletShoot = 1.5f;

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
        Direction = Target.transform.position - transform.position.normalized;
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y).normalized;
        /////////////////FIRE/////////////////////
        if (ShootCooldown >= BulletShoot)
        {
            for (int i = -2; i <= 2; i++)
            {
                fire(Quaternion.AngleAxis(i * 10, new Vector3(0, 0, 1)) * Direction.normalized);
            }

        }

    }

    void FixedUpdate()
    {
        rb2dAM.velocity = Movement;
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

    public void LoseHP(float LoseLife)
    {
        HP -= LoseLife;
    }
}
