﻿namespace MoviesApp.DTOs.MovieDTOs
{
    public class ChangePasswordDto
    {
        public string Username { get; set; } = string.Empty;
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}