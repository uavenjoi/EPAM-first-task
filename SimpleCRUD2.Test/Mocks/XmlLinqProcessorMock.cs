using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Test.Mocks
{
    public class XmlLinqProcessorMock : IXmlProcessor
    {
        public void CreateXmlFromCourseModel(CourseModel courseModel)
        {
        }

        public CourseModel GetCourseModelFromXml(string fileName)
        {
            if (fileName == "true.xml")
            {
                return new CourseModel() { IsDone = true };
            }

            return new CourseModel();
        }
    }
}
