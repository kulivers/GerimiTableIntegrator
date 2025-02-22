using YandexCloudOCR.Common;

namespace YandexCloudOCR.RecognitionStages;

public class StagesProcessor<TInput, TResult> : IStagesProcessor<TInput, TResult> where TResult : StageResult<TInput, TResult>
{
    public StageResult<TInput, TResult> Process(IEnumerable<IStage<TInput, TResult>> stages, TInput input)
    {
        StageResult<TInput, TResult> lastStageResult = default;
        var lastInput = input;
        foreach (var stage in stages)
        {
            lastStageResult = stage.Process(lastInput);
            if (lastStageResult.Success)
            {
                lastInput = lastStageResult.Value.ToInput();
            }
            else
            {
                if (!stage.ShouldContinueOnFail)
                {
                    return lastStageResult;
                }
            }
        }

        return lastStageResult!;
    }
}