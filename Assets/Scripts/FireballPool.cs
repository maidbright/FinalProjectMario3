using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireballPool : MonoBehaviour
{
    public static FireballPool Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private Fireball _fireballPrefab;

    private Queue<Fireball> _fireballPool = new Queue<Fireball>();



    public Fireball GetFireball(Vector2 startPoint)
    {
        if (_fireballPool.Count > 0)   
        {
            Fireball fireball = _fireballPool.Dequeue(); //убираем из очереди
            fireball.gameObject.SetActive(true); //делаем активным, имитация вытаскивания
            return fireball;
        }
        else
        {
            Fireball newFireball = Instantiate(_fireballPrefab, startPoint,Quaternion.identity).GetComponent<Fireball>(); 
            return newFireball;
        }
    }

    public void ReturnFireball(Fireball fireball)
    {
        _fireballPool.Enqueue(fireball);
    }

}
