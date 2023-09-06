﻿using MoviesApp.Domain.Enums;

namespace MoviesApp.DTOs.MovieDTOs
{
    public class RegisterUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Genre FavoriteGenre { get; set; }
    }
}