using System.Collections;
using UnityEngine;

public class Damageble : MonoBehaviour
{
    private bool _immortle;
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
        }
        else if (Inventory.Instance.GetShieldCount() > 0)
        {
            StartCoroutine(Immortle());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Immortle()
    {
        _immortle = true;
        yield return new WaitForSeconds(3);
        _immortle = false;
    }
}
