﻿namespace Vida.Application.Dtos.IdentityDtos;
public class AppUserResponse
{
	public string DisplayName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Token { get; set; } = string.Empty;
}