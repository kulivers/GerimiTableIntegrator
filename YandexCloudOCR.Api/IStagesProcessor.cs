using YandexCloudOCR.Common;

namespace YandexCloudOCR.RecognitionStages;

public interface IStagesProcessor<TInput, TResult> where TResult : StageResult<TInput, TResult>
{
    StageResult<TInput, TResult> Process(IEnumerable<IStage<TInput, TResult>> stages, TInput input);
}

public interface IStage<TInput, TResult> where TResult : StageResult<TInput, TResult>
{
    public bool ShouldContinueOnFail { get; set; }
    StageResult<TInput, TResult> Process(TInput input);
}

public abstract class StageResult<TInput, TResult> : Result<TResult>
{
    public abstract TInput ToInput();
}