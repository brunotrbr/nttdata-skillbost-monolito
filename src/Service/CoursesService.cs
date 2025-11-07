using src.Domain.Dtos;
using src.Domain.Models;
using src.Repository.Interface;
using src.Service.Interface;

namespace src.Service;

public class CoursesService(ICoursesRepository coursesRepository) : ICoursesService
{
    private readonly ICoursesRepository _coursesRepository = coursesRepository;

    
    public async Task<Courses> Create(CoursesDto courseDto)
    {
        var course = new Courses(courseDto);
        return await _coursesRepository.Create(course);
    }

    public async Task Delete(long id)
    {
        await _coursesRepository.Delete(id);
    }

    public async Task<Courses> Get(long id)
    {
        return await GetById(id);
    }

    public async Task<List<Courses>> List()
    {
        return await _coursesRepository.List();
    }

    public async Task<Courses> Update(long id, CoursesDto courseDto)
    {
        var existingCourse = await GetById(id);
        existingCourse.Update(courseDto);
        return await _coursesRepository.Update(existingCourse);
    }

    private async Task<Courses> GetById(long id)
    {
        return await _coursesRepository.Get(id) ?? throw new KeyNotFoundException($"Course with id {id} not found.");
    }

    
}
