﻿using System;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
	public string Name { get; set; }

	public ApplicationUser()
	{
	}
}
