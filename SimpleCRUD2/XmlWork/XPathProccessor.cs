using System;
using System.IO;
using System.Web;
using System.Xml;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.XmlWork
{
    public class XPathProccessor : IXmlProcessor
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUserRepository userRepository;

        public XPathProccessor(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            this.courseRepository = courseRepository;
            this.userRepository = userRepository;
        }

        public void CreateXmlFromCourseModel(CourseModel courseModel)
        {
            var xmlCourse = new XmlDocument();

            var course = xmlCourse.CreateElement("course");

            var courseId = xmlCourse.CreateElement("courseId");
            courseId.InnerText = courseModel.CourseId.ToString();

            var courseName = xmlCourse.CreateElement("courseName");
            courseName.InnerText = courseModel.Name;

            var isDone = xmlCourse.CreateElement("isDone");
            isDone.InnerText = courseModel.IsDone.ToString();

            var lessons = xmlCourse.CreateElement("lessonsList");

            foreach (var lessonItem in courseModel.Lessons)
            {
                var lesson = xmlCourse.CreateElement("lesson");

                var lessonId = xmlCourse.CreateElement("lessonId");
                lessonId.InnerText = lessonItem.LessonId.ToString();

                var lessonName = xmlCourse.CreateElement("lessonName");
                lessonName.InnerText = lessonItem.Name;

                var dateTime = xmlCourse.CreateElement("dateTime");
                dateTime.InnerText = lessonItem.DateTime.ToString();

                lesson.AppendChild(lessonId);
                lesson.AppendChild(lessonName);
                lesson.AppendChild(dateTime);

                lessons.AppendChild(lesson);
            }

            course.AppendChild(courseId);
            course.AppendChild(courseName);
            course.AppendChild(isDone);
            course.AppendChild(lessons);

            xmlCourse.AppendChild(course);

            var path = HttpContext.Current.Server.MapPath("~/Xml files/" + courseModel.Name + ".xml");

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
                var xmlCourse = new XmlDocument();
                xmlCourse.Load(stream);

                var courseNode = xmlCourse.SelectSingleNode("course");
                courseModel.CourseId = Convert.ToInt32(courseNode.SelectSingleNode("courseId").InnerText);
                courseModel.Name = courseNode.SelectSingleNode("courseName").InnerText;
                courseModel.IsDone = Convert.ToBoolean(courseNode.SelectSingleNode("isDone").InnerText);

                foreach (XmlNode lesson in courseNode.SelectNodes("//lesson"))
                {
                    var lessonModel = new LessonModel();

                    lessonModel.LessonId = Convert.ToInt32(lesson.SelectSingleNode("lessonId").InnerText);
                    lessonModel.Name = lesson.SelectSingleNode("lessonName").InnerText;
                    lessonModel.DateTime = Convert.ToDateTime(lesson.SelectSingleNode("dateTime").InnerText);

                    courseModel.Lessons.Add(lessonModel);
                }
            }

            return courseModel;
        }
    }
}