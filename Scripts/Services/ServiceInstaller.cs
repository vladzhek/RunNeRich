using Infastructure;
using UnityEngine;
using Zenject;

namespace Services
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private WindowsService _windowService;
        
        public override void InstallBindings()
        {
            InjectService.Instance.SetContainer(Container);
            
            BindMono();
            BindService();
            BindModel();
        }
        
        private void BindMono()
        {
            Container.Bind<WindowsService>().FromInstance(_windowService).AsSingle();
        }
    
        private void BindModel()
        {

        }
    
        private void BindService()
        {
            Container.Bind<StaticDataService>().AsSingle();
            Container.Bind<CurrencyService>().AsSingle();
            Container.Bind<EventService>().AsSingle();
        }
    }
}