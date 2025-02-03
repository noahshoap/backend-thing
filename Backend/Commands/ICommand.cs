public interface ICommand
{
  public Task<IResult> Execute();
}