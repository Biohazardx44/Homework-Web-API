﻿namespace MoviesApp.CustomExceptions
{
    public class UserDataException : Exception
    {
        public UserDataException(string message) : base(message) { }
    }
}