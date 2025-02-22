using YandexCloudOCR.Common;

namespace YandexCloudOCR.RecognitionStages;

public class StagesProcessor<TInput, TResult> : IStagesProcessor<TInput, TResult> where TResult : StageResult<TInput>
{
    public Result<TResult> Process(IEnumerable<IStage<TInput, TResult>> stages, TInput input)
    {
        Result<TResult> lastStageResult = default;
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