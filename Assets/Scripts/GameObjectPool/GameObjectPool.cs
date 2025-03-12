using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GameObjectPool<T> where T : MonoBehaviour //обощ типа Т с наследием от монобех
{
    protected T _prefab;
    protected Transform? _parent;
    protected Vector3 _startPos;
    /*public GameObjectPool(T prefab, int initialCount, Transform? parent, Vector3 startPos)
    {
        _prefab = prefab;
        _parent = parent;
        _startPos = startPos;

        for (int i = 0; i < initialCount; i++)
        {
            Get(_startPos);
        }
    }*/
    private Queue<T> _elements = new Queue<T>();

    public void Release(T element)
    {
        element.gameObject.SetActive(false);
        _elements.Enqueue(element);
    }

    public T Get(Vector2 startPos)
    {
        if (_elements.Count == 0)
        {
            //var element1 = Object.Instantiate(_prefab, _parent, false).GetComponent<T>(); //????Get component
            var element = Object.Instantiate(_prefab, startPos, Quaternion.identity, _parent).GetComponent<T>();
            element.gameObject.SetActive(false);
            _elements.Enqueue(element);
            return _elements.Dequeue();
        }
        else
        {
            var element = _elements.Dequeue();
            element.gameObject.SetActive(true); //делаем активным, имитация вытаскивания
            return element;
        }
    }
}
