using System;
using src.Domain.Dtos;
using src.Domain.Models;

namespace src.Repository.Interface;

public interface ICoursesRepository
{
    public abstract Task<Courses> Create(Courses course);

    public abstract Task<Courses> Get(long id);

    public abstract Task<List<Courses>> List();

    public abstract Task<Courses> Update(Courses course);

    public abstract Task Delete(long id);
}
