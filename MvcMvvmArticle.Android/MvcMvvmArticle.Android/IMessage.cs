﻿namespace MvcMvvmArticle.Android
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}