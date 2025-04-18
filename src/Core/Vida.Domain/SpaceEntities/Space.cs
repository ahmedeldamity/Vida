﻿using Vida.Domain.Common;

namespace Vida.Domain.SpaceEntities;
public class Space: BaseEntity
{
	public string Name { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string InstructorEmail { get; set; } = string.Empty;

	public string Type { get; set; } = string.Empty;

	public string ImageUrl { get; set; } = string.Empty;

	public decimal HourlyRate { get; set; }

	public int Capacity { get; set; }

	public bool RequiresApproval { get; set; }

	public bool IsActive { get; set; }
}