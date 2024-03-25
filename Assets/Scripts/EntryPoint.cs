using Data;
using Main;
using Services;
using UI.View;
using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private CardView _prefab;
    [SerializeField] private StaticData _staticData;
    
    private IGameStartService _gameStartService;
    private ICoroutineHandlerService _coroutineHandlerService;

    [Inject]
    public void Construct(IGameStartService gameStartService, ICoroutineHandlerService coroutineHandlerService)
    {
        _gameStartService = gameStartService;
        _coroutineHandlerService = coroutineHandlerService;
    }
    
    private void Start()
    {
        _coroutineHandlerService.CoroutineRunner = this;
        _gameStartService.Init(_staticData, _prefab);
        _gameStartService.StartGame();
    }
}