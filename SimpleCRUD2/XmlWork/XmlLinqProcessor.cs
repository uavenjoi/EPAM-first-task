using System;
using System.IO;
using System.Web;
using System.Xml.Linq;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.XmlWork
{
    public class XmlLinqProcessor : IXmlProcessor
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUserRepository userRepository;

        public XmlLinqProcessor(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            this.courseRepository = courseRepository;
            this.userRepository = userRepository;
        }

        public void CreateXmlFromCourseModel(CourseModel courseModel)
        {
            var xmlCourse = new XDocument();

            var course = new XElement("course");
            var courseId = new XElement("courseId", courseModel.CourseId.ToString());
            var courseName = new XElement("courseName", courseModel.Name);
            var isDone = new XElement("isDone", courseModel.IsDone.ToString());
            var lessons = new XElement("lessonsList");

            foreach (var lessonItem in courseModel.Lessons)
            {
                var lesson = new XElement("lesson");
                var lessonId = new XElement("lessonId", lessonItem.LessonId.ToString());
                var lessonName = new XElement("lessonName", lessonItem.Name);
                var dateTime = new XElement("dateTime", lessonItem.DateTime.ToString());

                lesson.Add(lessonId);
                lesson.Add(lessonName);
                lesson.Add(dateTime);

                lessons.Add(lesson);
            }

            course.Add(courseId);
            course.Add(courseName);
            course.Add(isDone);
            course.Add(lessons);

            xmlCourse.Add(course);

            var path = HttpContext.Current.Server.MapPath("~/Xml files/" + courseModel.Name);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                xmlCourse.Save(stream);
            }
        }

        public CourseModel GetCourseModelFromXml(string fileName)
        {
            var path = HttpContext.Current.Server.MapPath("~/Xml files/" + fileName);
            var courseModel = new CourseModel();

            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                var xmlCourse = XDocument.Load(stream);
                var rootNode = xmlCourse.Element("course");
                courseModel.CourseId = Convert.ToInt32(rootNode.Element("courseId").Value);
                courseModel.Name = rootNode.Element("courseName").Value;
                courseModel.IsDone = Convert.ToBoolean(rootNode.Element("isDone").Value);

                foreach (var lesson in xmlCourse.Element("course").Element("lessonsList").Elements("lesson"))
                {
                    var lessonModel = new LessonModel();

                    lessonModel.LessonId = Convert.ToInt32(lesson.Element("lessonId").Value);
                    lessonModel.Name = lesson.Element("lessonName").Value;
                    lessonModel.DateTime = Convert.ToDateTime(lesson.Element("dateTime").Value);

                    courseModel.Lessons.Add(lessonModel);
                }
            }

            return courseModel;
        }
    }
}