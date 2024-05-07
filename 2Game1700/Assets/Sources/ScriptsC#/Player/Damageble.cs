using System.Collections;
using System.Reflection;
using UnityEngine;

public class Damageble : MonoBehaviour
{
    private bool _immortle =false ;

    [SerializeField] private GameObject isEffect;
    [SerializeField] private AudioClip Swordsound;
    [SerializeField] private AudioClip Shieldsound;
    private AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyPatrolling enemy))
        {
            Damage(enemy.transform);
        }
    }

    private void Damage(Transform enemy)
    {
        if (_immortle) return;

        if (Inventory.Instance.GetSwordCount() > 0)
        {
            Inventory.Instance.RemoveItem(0);
            Destroy(enemy.gameObject);
            myAudio.PlayOneShot(Swordsound);
        }
        else if (Inventory.Instance.GetShieldCount() > 0)
        {
            StartCoroutine(Immortle());
            Inventory.Instance.RemoveItem(1);
            myAudio.PlayOneShot(Shieldsound);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Immortle()
    {
        _immortle = true;      
        isEffect.SetActive(_immortle);
        yield return new WaitForSeconds(3);
        _immortle = false;      
        isEffect.SetActive(_immortle);
    }
}
