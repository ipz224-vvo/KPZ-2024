﻿namespace lab_1.Interfaces;

public interface ILogger
{
    void Info(string message);
    void Warning(string message);
    void Error(string message);
}
