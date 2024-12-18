﻿namespace VectorCode.DataSeed.Test.TestDataSeed;

public class TestSeedRunner : BaseDataSeedRunner
{

  public TestSeedRunner(IDataSeedRepository dataSeedRepository, IFileHashGenerator fileHashGenerator) : base(dataSeedRepository, fileHashGenerator)
  {
  }

  private string _folder = "TestDataSeed/Pass";
  protected override string Folder => _folder;
  public void SetFolder(string folder)
  {
    _folder = folder;
  }

  public override Func<dynamic, Task>? GetStep(Type itemType)
  {
    if (itemType == typeof(StepOneModel))
    {
      return (dynamic i) => DoStepOne((i as StepOneModel)!);
    }
    if (itemType == typeof(StepTwoModel))
    {
      return (dynamic i) => DoStepTwo((i as StepTwoModel)!);
    }
    if(itemType == typeof(EnumPropModel))
    {
      return (dynamic i) => DoEnum((i as EnumPropModel)!);
    }
    return null;
  }

  public List<StepOneModel> StepOneModels = new List<StepOneModel>();
  public Task DoStepOne(StepOneModel model)
  {
    if (model.Number < 0) throw new InvalidOperationException("Number must be greater than 0");
    StepOneModels.Add(model);
    return Task.CompletedTask;
  }

  public List<StepTwoModel> StepTwoModels = new List<StepTwoModel>();
  public Task DoStepTwo(StepTwoModel model)
  {
    StepTwoModels.Add(model);
    return Task.CompletedTask;
  }

  public List<EnumPropModel> EnumPropModels = new List<EnumPropModel>();
  public Task DoEnum(EnumPropModel model)
  {
    EnumPropModels.Add(model);
    return Task.CompletedTask;
  }


}
