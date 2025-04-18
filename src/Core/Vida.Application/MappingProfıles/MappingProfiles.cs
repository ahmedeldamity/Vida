﻿using AutoMapper;
using Vida.Application.Dtos.CourseDtos;
using Vida.Application.Dtos.SpaceDtos;
using Vida.Domain.SpaceEntities;

namespace Vida.Application.MappingProfıles;
public class MappingProfiles: Profile
{
	public MappingProfiles()
	{
		CreateMap<Space, SpaceResponse>();

		CreateMap<CourseReservationRequest, CourseReservation>();

		CreateMap<SpaceReservationRequest, SpaceReservation>();
	}
}