﻿using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;

namespace mlp.interviews.boxing.problem.Interface.Interfaces
{
    public interface IFileFormatConverter
    {
        string[] Convert(List<OutputRecord> outputRecords);
    }
}