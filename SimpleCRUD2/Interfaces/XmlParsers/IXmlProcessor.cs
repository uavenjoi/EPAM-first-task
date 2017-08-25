using SimpleCRUD2.Models;

namespace SimpleCRUD2.Interfaces
{
    public interface IXmlProcessor
    {
        void CreateXmlFromCourseModel(CourseModel courseModel);

        CourseModel GetCourseModelFromXml(string fileName);
    }
}
