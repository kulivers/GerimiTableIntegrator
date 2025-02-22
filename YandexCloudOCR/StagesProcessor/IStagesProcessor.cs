using YandexCloudOCR.Common;

namespace YandexCloudOCR.RecognitionStages;

public interface IStagesProcessor<TInput, TResult> where TResult : StageResult<TInput>
{
    Result<TResult> Process(IEnumerable<IStage<TInput, TResult>> stages, TInput input);
}

public interface IStage<in TInput, TResult> where TResult : StageResult<TInput>
{
    public bool ShouldContinueOnFail { get; set; }
    Result<TResult> Process(TInput input);
}

public abstract class StageResult<TInput>
{
    public abstract TInput ToInput();
}