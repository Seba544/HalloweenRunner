using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[CreateAssetMenu(fileName = "Game Events", menuName = "Game/Game Events", order = 1)]
public class GameEvent : ScriptableObject
{
    private Subject<Unit> _collectPumpking = new Subject<Unit>();
    private Subject<Unit> _pauseGame = new Subject<Unit>();
    private Subject<Unit> _resumeGame = new Subject<Unit>();
    private Subject<Unit> _gameOver = new Subject<Unit>(); 
    public ISubject<String> LoadScene = new Subject<String>();
    private Subject<Unit> _endWave = new Subject<Unit>();
    private ISubject<Unit> _endOfLevel = new Subject<Unit>();
    private ISubject<int> _giveReward = new Subject<int>();
    private ISubject<Unit> _giveRewardBonus = new Subject<Unit>();
    private ISubject<Unit> _revive = new Subject<Unit>();
    private ISubject<Unit> _showExtraLifeVR = new Subject<Unit>();
    private ISubject<Unit> _showMultiplyRewardVR = new Subject<Unit>();
    private ISubject<Unit> _finalizeMultiplyRewardVR = new Subject<Unit>();
    
    public IObservable<Unit> CollectPumpking(){
        _collectPumpking.OnNext(Unit.Default);
        return _collectPumpking;

    }
    public IObservable<Unit> PauseGame(){
        _pauseGame.OnNext(Unit.Default);
        return _pauseGame;
    }
    public IObservable<Unit> ResumeGame(){
        _resumeGame.OnNext(Unit.Default);
        return _resumeGame;
    }
    public IObservable<Unit> OnGameOver() => _gameOver; 
    
    public IObservable<Unit> EndWave ()=> _endWave;
    public IObservable<Unit> OnEndOfLevel () => _endOfLevel;
    public IObservable<int> OnGiveReward () => _giveReward;
    public IObservable<Unit> OnRevive() =>_revive;
    public IObservable<Unit> OnShowExtraLifeVR => _showExtraLifeVR;
    public IObservable<Unit> OnShowMultiplyRewardVR => _showMultiplyRewardVR;
    public IObservable<Unit> OnGiveRewardBonus() => _giveRewardBonus;
    
    public void OnEndWave() => _endWave.OnNext(Unit.Default);
    public void EndOfLevel() => _endOfLevel.OnNext(Unit.Default);
    public void GameOver(){
        _gameOver.OnNext(Unit.Default);
        
    } 
    public void GiveReward(int pumpkingsAmount) => _giveReward.OnNext(pumpkingsAmount);
    public void GiveRewardBonus() => _giveRewardBonus.OnNext(Unit.Default);
    public void Revive() => _revive.OnNext(Unit.Default);
    public void ShowExtraLifeVR() => _showExtraLifeVR.OnNext(Unit.Default);
    public void ShowMultiplyRewardVR() => _showMultiplyRewardVR.OnNext(Unit.Default);

    
}
