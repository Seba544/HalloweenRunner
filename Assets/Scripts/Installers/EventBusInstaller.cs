using System.Collections;
using System.Collections.Generic;
using Events;
using Installers;
using UnityEngine;

public class EventBusInstaller : Installer
{
    public override void Install(ServiceLocator serviceLocator)
    {
        serviceLocator.RegisterService<IEventBus>(new GameEventBus());
    }
}
