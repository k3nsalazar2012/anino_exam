using Zenject;
using Anino.Framework;
using Anino.Implementation;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindServices();
        BindEntities();
    }

    private void BindServices()
    {
        Container.BindInterfacesAndSelfTo<PayoutService>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<CurrencyService>().AsSingle().NonLazy();
    }

    private void BindEntities()
    {
         Container.BindInterfacesAndSelfTo<Currency>().AsSingle().NonLazy();
    }
}
