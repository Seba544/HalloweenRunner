using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Builder;
using Component_Models.Contracts;
using Controllers;
using TMPro;
using UnityEngine;

public class CandyScore : MonoBehaviour
{
    private ICandyScoreController m_controller;
    private int _currentAmountOfCandies;
    [SerializeField] private TMP_Text _amountOfCandiesTxt;
    private void Awake()
    {
        var builder = new CandyScoreControllerBuilder();
        builder.Create();
        m_controller = builder.GetCandyScoreComponentModel();

        m_controller.PropertyChanged += OnPropertyChanged;
    }

    private void Start()
    {
        _currentAmountOfCandies = 0;
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(m_controller.AmountOfCandies))
        {
            _currentAmountOfCandies = m_controller.AmountOfCandies;
            UpdateAmountOfCandiesCollected(_currentAmountOfCandies);
        }
    }

    private void UpdateAmountOfCandiesCollected(int amountOfCandies)
    {
        _amountOfCandiesTxt.text = amountOfCandies.ToString();
    }

    private void OnDestroy()
    {
        m_controller.Dispose();
    }
}
