﻿using AutoMapper;
using Vida.Application.Dtos.CourseDtos;
using Vida.Application.Interfaces.Repositories;
using Vida.Application.Interfaces.Services;
using Vida.Application.Specifications;
using Vida.Domain.ErrorHandling;
using Vida.Domain.SpaceEntities;

namespace Vida.Infrastructure.Services;
public class CourseService(IUnitOfWork unitOfWork, IMapper mapper) : ICourseService
{
	public async Task<Result<IReadOnlyList<Course>>> GetCoursesAsync()
	{
		var spec = new BaseSpecifications<Course> { IncludesCriteria = [ x => x.Availability ] };

		var courses = await unitOfWork.Repository<Course>().GetAllAsync(spec);

		return Result.Success(courses);
	}

	public async Task<Result<Course>> CourseReservationAsync(CourseReservationRequest model)
	{
		var courseReservation = mapper.Map<CourseReservationRequest, CourseReservation>(model);

		await unitOfWork.Repository<CourseReservation>().AddAsync(courseReservation);

		var result = await unitOfWork.CompleteAsync();

		if (result <= 0)
			return Result.Failure<Course>(new Error(500, "An error occurred while reserving the course"));

		var course = await unitOfWork.Repository<Course>().GetEntityAsync(courseReservation.CourseId);

		if (course == null)
			return Result.Failure<Course>(new Error(404, $"Course with id {courseReservation.CourseId} not found"));

		return Result.Success(course);
	}
}