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
    AudioClip EnnemyDamage;
    [SerializeField]
    AudioClip PlayerDamage;
    [SerializeField]
    AudioClip OpenChest;
    [SerializeField]
    AudioClip PickKey;
    [SerializeField]
    AudioClip PickHearth;
    [SerializeField]
    AudioClip BossDoor;
    [SerializeField]
    AudioClip DonjonMusic;
    [SerializeField]
    AudioClip BossMusic;
    
       
	
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
    void BasicFire()
    {
        MakeSound(BasicShot);
    }
    void Ak_47Fire()
    {
        MakeSound(AK_47Shot);
    }
    void ShotgunFire()
    {
        MakeSound(ShotgunShot);
    }
    void SniperFire()
    {
        MakeSound(SniperShot);
    }
    void BigBulletFire()
    {
        MakeSound(BigBullet);
    }
    void CircleFire()
    {
        MakeSound(CircleShot);
    }
    void TornadoFire()
    {
        MakeSound(TornadoShot);
    }
    void EnnemyHurt()
    {
        MakeSound(EnnemyDamage);
    }
    void PlayerHurt()
    {
        MakeSound(PlayerDamage);
    }
    void ChestOpen()
    {
        MakeSound(OpenChest);
    }
    void KeyPick()
    {
        MakeSound(PickKey);
    }
    void HearthPick()
    {
        MakeSound(PickHearth);
    }
    void OpenBossDoor()
    {
        MakeSound(BossDoor);
    }
    void DungeonMusic()
    {
        MakeSound(DonjonMusic);
    }
    void BossBattleMusic()
    {
        MakeSound(BossMusic);
    }
}
