using Microsoft.AspNetCore.Mvc;
using src.Domain.Dtos;
using src.Domain.Models;
using src.Service.Interface;

namespace src.Controller.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICoursesService coursesService, ICourseActivityService courseActivityService) : ControllerBase
    {
        private readonly ICoursesService _coursesService = coursesService ?? throw new ArgumentNullException(nameof(coursesService));
        private readonly ICourseActivityService _courseActivityService = courseActivityService ?? throw new ArgumentNullException(nameof(courseActivityService));

        [HttpGet]
        [Route("{courseId:long}/activities")]
        public async Task<List<CourseActivity>> ListCourseActivities(long courseId)
        {
            return await _courseActivityService.ListByCourseId(courseId);
        }

        [HttpPost]
        [Route("{courseId:long}/activities")]
        public async Task<ActionResult<CourseActivity>> Create(long courseId, [FromBody] CourseActivityDto courseActivityDto)
        {
            var createdCourseActivity = await _courseActivityService.Create(courseId, courseActivityDto);
            return CreatedAtAction(nameof(Get), new { activityId = createdCourseActivity.Id  }, createdCourseActivity);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Courses>>> List()
        {
            return Ok(await _coursesService.List());
        }

        [HttpGet]
        [Route("{courseId:long}")]
        public async Task<ActionResult<Courses>> Get(long courseId)
        {
            return Ok(await _coursesService.Get(courseId));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Courses>> Create([FromBody] CoursesDto courseDto)
        {
            var createdCourse = await _coursesService.Create(courseDto);
            return CreatedAtAction(nameof(Get), new { courseId = createdCourse.Id }, createdCourse);
        }

        [HttpPatch]
        [Route("{courseId:long}")]
        public async Task<ActionResult> Update(long courseId, [FromBody] CoursesDto courseDto)
        {
            return Ok(await _coursesService.Update(courseId, courseDto));
        }

        [HttpDelete]
        [Route("{courseId:long}")]
        public async Task<ActionResult> Delete(long courseId)
        {
            await _coursesService.Delete(courseId);
            return NoContent();
        }
    }
}
