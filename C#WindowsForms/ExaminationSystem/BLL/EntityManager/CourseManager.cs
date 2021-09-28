using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using BLL.EntityList;
using BLL.EntityLists;
using DAL;

namespace BLL.Entities
{
    public class CourseManager
    {
        private static CourseManager _instance;
        DBManager dbManager = DBManager.getInstance();

        private CourseManager()
        {

        }
        public static CourseManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new CourseManager();
            }

            return _instance;
        }
        public InstructorsList SelectAllInstructors()
        {
            try
            {
                return (DataTableToInstructorsList(dbManager.ExecuteDataTable("SP_SelectInstructors")));

            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return new InstructorsList();

        }
        public CoursesList SelectAllCourses()
        {
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            { ["col"] = "*", ["t"] = "Course" };
            try
            {
                return (DataTableToCoursesList(
            dbManager.ExecuteDataTable("Sp_getDetails", ParamList)));
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return new CoursesList();

        }

        public bool InsGenerateExam(string courseID, string examDateTime, string type)
        {
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            {
                ["CourseID"] = courseID,
                ["ExamDate"] = examDateTime,
                ["examType"] = type
            };
            try
            {
                if (dbManager.ExecuteNonQuery("Sp_InsGenerateExam", ParamList) > 0)
                    return true;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return false;
        }

        internal CoursesList DataTableToCoursesList(DataTable Dt)
        {
            CoursesList courses = new CoursesList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    courses.Add(DataRowToCourse(item));
                }
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }

            return courses;
        }
        internal Course DataRowToCourse(DataRow Dr)
        {
            Course course = new Course();
            course.State = EntityState.UnChanged;
            try
            {
                int tempInt; decimal tempDecimal;

                course.CourseID = Dr["CourseID"].ToString();
                if (int.TryParse(Dr["CourseMarks"]?.ToString() ?? "NA", out tempInt))
                    course.CourseMarks = tempInt;
                course.CourseName = Dr["CourseName"].ToString();
                if (decimal.TryParse(Dr["CoursePassPercentage"]?.ToString() ?? "NA", out tempDecimal))
                    course.CoursePassPercentage = tempDecimal;
                if (int.TryParse(Dr["MaxNoOfStuds"]?.ToString() ?? "NA", out tempInt))
                    course.MaxNoOfStuds = tempInt;
                if (int.TryParse(Dr["InstID"]?.ToString() ?? "NA", out tempInt))
                    course.InstID = tempInt;
                course.State = EntityState.UnChanged;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }

            return course;
        }

        internal InstructorsList DataTableToInstructorsList(DataTable Dt)
        {
            InstructorsList instructors = new InstructorsList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    instructors.Add(DataRowToInstructors(item));
                }

            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return instructors;


        }
        internal Instructor DataRowToInstructors(DataRow Dr)
        {
            Instructor instructor = new Instructor();
            instructor.State = EntityState.UnChanged;
            try
            {
                int TempInt;
                if (int.TryParse(Dr["InstructID"]?.ToString() ?? "0", out TempInt))
                    instructor.InstID = TempInt;
                instructor.InstFName = Dr["InstFName"]?.ToString() ?? "NA";
                instructor.InstLName = Dr["InstLName"]?.ToString() ?? "NA";
                instructor.State = EntityState.UnChanged;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return instructor;

        }
    }
}
