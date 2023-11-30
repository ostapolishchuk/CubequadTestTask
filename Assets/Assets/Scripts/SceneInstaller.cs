using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private CanvasController _canvasPrefab;
    [SerializeField] private PlayerController _playerPrefab;
    
    public override void InstallBindings()
    {
        Container.Bind<LevelController>().FromInstance(FindObjectOfType<LevelController>()).AsSingle();
        Container.Bind<PlayerController>().FromComponentInNewPrefab(_playerPrefab).AsSingle();
        Container.Bind<CanvasController>().FromComponentInNewPrefab(_canvasPrefab).AsSingle();
    }
}