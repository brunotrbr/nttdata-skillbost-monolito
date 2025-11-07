using src.Domain.Dtos;
using src.Domain.Models;

namespace src.Service.Interface;

public interface ICoursesService
{
    public abstract Task<Courses> Create(CoursesDto courseDto);

    public abstract Task<Courses> Get(long id);

    public abstract Task<List<Courses>> List();

    public abstract Task<Courses> Update(long id, CoursesDto courseDto);

    public abstract Task Delete(long id);
}
