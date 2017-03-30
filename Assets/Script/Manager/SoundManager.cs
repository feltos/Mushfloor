using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField]
    AudioClip BasicShot;
    [SerializeField]
    AudioClip AK_47Shot;
    [SerializeField]
    AudioClip ShotgunShot;
    [SerializeField]
    AudioClip SniperShot;
    [SerializeField]
    AudioClip BigBullet;
    [SerializeField]
    AudioClip CircleShot;
    [SerializeField]
    AudioClip TornadoShot;
    [SerializeField]
    AudioClip EnnemyDeath;
    [SerializeField]
    AudioClip PlayerDamage;
    [SerializeField]
    AudioClip OpenChest;
    [SerializeField]
    AudioClip PickKey;
    [SerializeField]
    AudioClip PickGun;
    [SerializeField]
    AudioClip PickHearth;


    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Multiple instances of SoundEffects!");
        }
        Instance = this;
    }

    void Start ()
    {
        DontDestroyOnLoad(this);
	}
	
	
	void Update ()
    {
        
	}

    private void MakeSound(AudioClip OriginalClip)
    {
        AudioSource.PlayClipAtPoint(OriginalClip, transform.position);
    }
    public void BasicFire()
    {
        MakeSound(BasicShot);
    }
    public void Ak_47Fire()
    {
        MakeSound(AK_47Shot);
    }
    public void ShotgunFire()
    {
        MakeSound(ShotgunShot);
    }
    public void SniperFire()
    {
        MakeSound(SniperShot);
    }
    public void BigBulletFire()
    {
        MakeSound(BigBullet);
    }
    public void CircleFire()
    {
        MakeSound(CircleShot);
    }
    public void TornadoFire()
    {
        MakeSound(TornadoShot);
    }
    public void EnnemyHurt()
    {
        MakeSound(EnnemyDeath);
    }
    public void PlayerHurt()
    {
        MakeSound(PlayerDamage);
    }
    public void ChestOpen()
    {
        MakeSound(OpenChest);
    }
    public void KeyPick()
    {
        MakeSound(PickKey);
    }
    public void HearthPick()
    {
        MakeSound(PickHearth);
    }
    public void GunPick()
    {
        MakeSound(PickGun);
    }
}
