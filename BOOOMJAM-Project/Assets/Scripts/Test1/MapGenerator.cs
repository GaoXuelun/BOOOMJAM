using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("StreetCut")]
    [SerializeField] private GameObject[] _streets;
    [SerializeField] private float _stayTime = 5.0f;

    private bool _isGenerated;
    private float _existenceTime;

    public void GenerateMap()
    {
        if (_streets == null) return;
        int randomStreetNum = Random.Range(0, _streets.Length);
        GameObject street = Instantiate(_streets[randomStreetNum], transform.position, transform.rotation) as GameObject;
        street.name = street.name.Replace("(Clone)", "").Trim();

        _isGenerated = true;
    }

    private void Update()
    {
        if (!_isGenerated) return;
        _existenceTime += Time.deltaTime;
        Debug.Log("existence time: " + _existenceTime);
        if (_existenceTime >= _stayTime)
        {
            _existenceTime = 0;
            _isGenerated = false;
            Destroy(transform.parent.parent.gameObject);
        }
    }
}
