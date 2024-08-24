using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour //в зависимости от типа пули -- определение типа пули
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _endPoint; //player
    public void Shoot()
    {
        Fireball fireball = FireballPool.Instance.GetFireball(_firePoint.position);
        fireball.transform.SetParent(transform);
        fireball.Direction = -(fireball.transform.right + fireball.transform.up);
        StartCoroutine(IsActiveFireBall(fireball));
    }

    public IEnumerator IsActiveFireBall(Fireball fireball)
    {
        if(!fireball.gameObject.activeSelf)
        {
            FireballPool.Instance.ReturnFireball(fireball);
            yield break;
        }
        yield return null;
    }
  
}
