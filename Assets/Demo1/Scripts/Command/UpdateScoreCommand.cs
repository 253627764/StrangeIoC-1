using strange.extensions.command.impl;

public class UpdateScoreCommand : EventCommand {
    [Inject]public ScoreModel scoreModel { get; set; }
    [Inject]public IScoreService scoreService { get; set; }

    //dispatcher通过事件触发时调用
    public override void Execute()
    {
        scoreModel.Score++;
        scoreService.UpdateScore("http://wwww.xxxxx.com",scoreModel.Score);

        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange,scoreModel.Score);
    }
}
