using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Builder;
using Component_Models.Contracts;
using TMPro;
using UnityEngine;

public class CandyScore : MonoBehaviour
{
    private ICandyScoreComponentModel _componentModel;
    private int _currentAmountOfCandies;
    [SerializeField] private TMP_Text _amountOfCandiesTxt;
    private void Awake()
    {
        var builder = new CandyScoreComponentModelBuilder();
        builder.Create();
        _componentModel = builder.GetCandyScoreComponentModel();

        _componentModel.PropertyChanged += OnPropertyChanged;
    }

    private void Start()
    {
        _currentAmountOfCandies = 0;
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_componentModel.AmountOfCandies))
        {
            _currentAmountOfCandies = _componentModel.AmountOfCandies;
            UpdateAmountOfCandiesCollected(_currentAmountOfCandies);
        }
    }

    private void UpdateAmountOfCandiesCollected(int amountOfCandies)
    {
        _amountOfCandiesTxt.text = amountOfCandies.ToString();
    }

    private void OnDestroy()
    {
        _componentModel.Dispose();
    }
}
