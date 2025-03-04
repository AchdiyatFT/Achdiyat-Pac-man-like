using System;
using System.Collections.Generic;
using UnityEngine;

public class Pickablemanager : MonoBehaviour
{
    private List<Pickable> _pickableList = new List<Pickable>();
    [SerializeField] private Player _player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitPickableList();
    }

    private void InitPickableList()
    {
        Pickable[] pickableObjects = GameObject.FindObjectsOfType<Pickable>();
        for (int i = 0; i < pickableObjects.Length; i++)
        {
            _pickableList.Add(pickableObjects[i]);
            pickableObjects[i].OnPicked += OnPickablePicked;
        }
        Debug.Log("Pickable List:" + _pickableList);
    }

    private void OnPickablePicked(Pickable pickable)
    {
        _pickableList.Remove(pickable);
        if (_pickableList.Count <= 0)
        {
            if (pickable.PickableType == PickableType.PowerUp)
            {
                _player?.PickPowerUp();
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
