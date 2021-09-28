using BLL.Entities;
using BLL.EntityList;
using BLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace BLL.EntityManager
{
    public class ExamManager
    {
        private static ExamManager _instance;
        DBManager dbManager = DBManager.getInstance();
        string courseID;
        public string CourseID
        {
            get => courseID;
            set
            {
                if ((value != courseID))
                    courseID = value;
            }
        }
        int examID;
        public int ExamID
        {
            get => examID;
            set
            {
                if ((value != examID))
                    examID = value;

            }
        }

        private ExamManager()
        {


        }
        public static ExamManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new ExamManager();
            }

            return _instance;
        }

        public QuestionsList SelectExamQuestions()
        {
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            {
                ["ExamID"] = ExamID
            };
            try
            {
                return DataTableToStudentQuestions(dbManager.ExecuteDataTable("getExamQuestions", ParamList));
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return new QuestionsList();
        }
        public ChoicesList SelectExamChoices()
        {
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            {
                ["CourseID"] = courseID
            };
            try
            {
                return DataTableToStudentChoices(dbManager.ExecuteDataTable("SP_getExamChoices", ParamList));
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return new ChoicesList();
        }
        public CoursesList SelectCoursesExams()
        {

            try
            {
                return (DataTableToCoursesList(
            dbManager.ExecuteDataTable("SP_SelectCoursesExams")));
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return new CoursesList();
        }
        public ExamsList SelectCoursesSpecificExam()
        {
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            {
                ["CourseID"] = courseID
            };

            try
            {
                return (DataTableToExams(
            dbManager.ExecuteDataTable("SP_SelectCoursesSpecificExam", ParamList)));
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return new ExamsList();
        }

        public int TakeAnswers(int studID, string StudAnswer, int quesID, string quesType)
        {
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            {
                ["ExamID"] = examID,
                ["CourseID"] = courseID,
                ["StudID"] = studID,
                ["StudAnswer"] = StudAnswer,
                ["quesID"] = quesID,
                ["quesType"] = quesType,
            };
            try
            {
                if (dbManager.ExecuteNonQuery("Sp_TakeAnswers", ParamList) > 0)
                    return 1;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return -1;

        }

        public int ExamCorrection(int studID)
        {
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            {
                ["ExamID"] = examID,
                ["StudID"] = studID
            };
            try
            {
                if (dbManager.ExecuteNonQuery("Sp_ExamCorrection", ParamList) > 0)
                    return 1;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return -1;

        }
        public int courseFullMark()
        {
            int r = -1;
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            {
                ["ExamID"] = examID
            };
            try
            {
                r = (int)(dbManager.ExecuteScaler("Sp_courseFullMark", ParamList));
                if (r > 0)
                    return r;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return r;

        }
        public int sumOfMarksPerCourse(int studID)
        {
            int r = -1;
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            {
                ["CourseID"] = courseID,
                ["ExamID"] = examID,
                ["StudID"] = studID
            };
            try
            {
                r = (int)(dbManager.ExecuteScaler("Sp_sumOfMarksPerCourse", ParamList));
                if (r > 0)
                    return r;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return r;

        }

        internal QuestionsList DataTableToStudentQuestions(DataTable Dt)
        {
            QuestionsList questions = new QuestionsList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    questions.Add(DataRowToStudentQuestion(item));
                }
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }

            return questions;
        }
        internal Question DataRowToStudentQuestion(DataRow Dr)
        {
            Question examQuestion = new Question();
            examQuestion.State = EntityState.UnChanged;
            try
            {
                int tempInt;

                examQuestion.QuestType = Dr["QuestType"].ToString();
                examQuestion.QuestBody = Dr["QuestBody"].ToString();
                if (int.TryParse(Dr["QuestID"]?.ToString() ?? "NA", out tempInt))
                    examQuestion.QuestID = tempInt;
                if (int.TryParse(Dr["Marks"]?.ToString() ?? "NA", out tempInt))
                    examQuestion.Marks = tempInt;

                examQuestion.State = EntityState.UnChanged;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }

            return examQuestion;
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

                course.CourseID = Dr["CourseID"].ToString();
                course.CourseName = Dr["CourseName"].ToString();

                course.State = EntityState.UnChanged;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }

            return course;
        }

        internal ChoicesList DataTableToStudentChoices(DataTable Dt)
        {
            ChoicesList choices = new ChoicesList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    choices.Add(DataRowToStudentChoice(item));
                }
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }

            return choices;
        }
        internal Choice DataRowToStudentChoice(DataRow Dr)
        {
            Choice examChoice = new Choice();
            examChoice.State = EntityState.UnChanged;
            try
            {
                int tempInt;

                examChoice.QuestType = Dr["QuestType"].ToString();
                examChoice.QuestChoices = Dr["QuestChoices"].ToString();
                if (int.TryParse(Dr["QuestID"]?.ToString() ?? "NA", out tempInt))
                    examChoice.QuestID = tempInt;


                examChoice.State = EntityState.UnChanged;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }

            return examChoice;
        }

        internal ExamsList DataTableToExams(DataTable Dt)
        {
            ExamsList exams = new ExamsList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    exams.Add(DataRowToStudentExam(item));
                }
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }

            return exams;
        }
        internal Exam DataRowToStudentExam(DataRow Dr)
        {
            Exam exam = new Exam();
            exam.State = EntityState.UnChanged;
            try
            {
                int tempInt;

                exam.ExamDatetime = Dr["ExamDatetime"].ToString();
                if (int.TryParse(Dr["ExamID"]?.ToString() ?? "NA", out tempInt))
                    exam.ExamID = tempInt;


                exam.State = EntityState.UnChanged;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }

            return exam;
        }

    }
}
