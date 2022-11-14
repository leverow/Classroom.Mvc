using Classroom.Mvc.Models;
using Classroom.Mvc.Repository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Classroom.Mvc.Services;

public class SchoolService : ISchoolService
{
    private readonly ILogger<SchoolService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public SchoolService(
        ILogger<SchoolService> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<School>> CreateAsync(School school)
    {
        if(school is null) throw new ArgumentNullException(nameof(school));

        if (string.IsNullOrWhiteSpace(school.Name)) return new("Name is invalid");
        
        var retrievedSchool = _unitOfWork.Schools.GetAll().FirstOrDefault(s => s.Name == school.Name);
        if (retrievedSchool != null) return new("School already exists");

        var entity = school.Adapt<Entities.School>();

        try
        {
            var createdSchool = await _unitOfWork.Schools.AddAsync(entity);
            return new(true) { Data = createdSchool.Adapt<Models.School>() };
        }
        catch(Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(SchoolService)}", exception);
            throw new("Couldn't create school. Contact support.", exception);
        }
    }

    public async Task<bool> Exists(Guid id)
    {
        var existedSchoolResult = await GetSchoolByIdAsync(id);
        return existedSchoolResult.IsSuccess;
    }

    public async Task<Result<IEnumerable<School>>> GetAllSchoolsAsync()
    {
        var existingSchools = _unitOfWork.Schools.GetAll();
        if (existingSchools is null) return new("No schools found.");
        
        try
        {
            var selectedSchools = await existingSchools.Select(s => s.Adapt<Models.School>()).ToListAsync();
            return new(true) { Data = selectedSchools};
        }
        catch(Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(SchoolService)}", exception);
            throw new($"Couldn't get schools. Contact support.", exception);
        }
    }

    public async Task<Result<School>> GetSchoolByIdAsync(Guid id)
    {
        try
        {
            var existingSchool = await _unitOfWork.Schools.GetAll().FirstOrDefaultAsync(s => s.Id == id);
            if (existingSchool is null) return new("School with given id not found.");

            return new(true) { Data = existingSchool.Adapt<Models.School>() };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(SchoolService)}", exception);
            throw new($"Couldn't get school. Contact support.", exception);
        }
    }

    public async Task<Result<School>> RemoveByIdAsync(Guid id)
    {
        try
        {
            var existingSchool = _unitOfWork.Schools.GetById(id);
            if (existingSchool is null) return new("School with given id not found.");

            var removedResult = await _unitOfWork.Schools.RemoveAsync(existingSchool);
            if (removedResult is null) return new("Removing the school failed. Contact support.");

            return new(true) { Data = removedResult.Adapt<Models.School>() };
        }
        catch(Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(SchoolService)}", exception);
            throw new("Couldn't remove the school. Contact support.", exception);
        }
    }

    public async Task<Result<School>> UpdateAsync(Guid id, School school)
    {
        if (school is null) throw new ArgumentNullException(nameof(school));

        if (string.IsNullOrWhiteSpace(school.Name)) return new("Name is invalid");

        var existingSchool = _unitOfWork.Schools.GetById(id);
        if (existingSchool is null) return new("School not found.");

        try
        {
            var updatedSchool = await _unitOfWork.Schools.UpdateAsync(existingSchool);
            if (updatedSchool is null) return new("Updating school failed.");

            return new(true) { Data = updatedSchool.Adapt<Models.School>() };
        }
        catch(Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(SchoolService)}", exception);
            throw new("Couldn't update the school. Contact support.", exception);
        }
    }
}