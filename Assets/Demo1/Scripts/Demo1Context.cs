using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.injector.impl;

public class Demo1Context :MVCSContext 
{
    public Demo1Context(MonoBehaviour view) : base(view) { }//构造函数

    protected override void mapBindings()//绑定
    {
        //manger
        injectionBinder.Bind<AudioManger>().To<AudioManger>().ToSingleton();

        //Model，接口（如果构造了）绑定到实现类，调用接口时IoC自动注入
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();

        //mediator，view绑定到mediator，调用view时IoC自动注入
        mediationBinder.Bind<CubeView>().To<CubeMediator>();

        //command,事件（枚举）绑定到command，全局分发器（dispacher）直接通过事件触发command
        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdateScore).To<UpdateScoreCommand>();

        //service，接口绑定到实现类，调用接口时IoC自动注入
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();//表示这个对象只会在整个工程中生成一个

        //绑定开始事件，自动触发startcommand命令
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();        
    }
}

