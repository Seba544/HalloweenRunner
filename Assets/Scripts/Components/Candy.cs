using System;
using System.Collections;
using System.Collections.Generic;
using Builder;
using Component_Models;
using Component_Models.Contracts;
using Components.Contracts;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private ICandyComponentModel _componentModel;
    private void Awake()
    {
        var builder = new CandyComponentModelBuilder();
        builder.Create();
        _componentModel = builder.GetCandyComponentModel();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _componentModel.CollectCandy();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        _componentModel.Dispose();
    }
    
}


