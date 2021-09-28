using BLL.Entities;
using BLL.EntityLists;
using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationUI
{
    public partial class StExamRetrival : Form
    {
        public StExamRetrival()
        {
            InitializeComponent();
        }
        QuestionsList examQuestions;
        ChoicesList examChoices;
        int QuestionCounter = 0;
        ExamManager manager = ExamManager.getInstance();
        StudentAnswers answers;
        Question q, q2;
        private void StExamRetrival_Load(object sender, EventArgs e)
        {
            examQuestions = manager.SelectExamQuestions();
            examChoices = manager.SelectExamChoices();
            answers = new StudentAnswers();

            PracticalExam();
            Console.WriteLine(examQuestions.Count == (int)(ExamType.Final));
            Console.WriteLine(examQuestions.Count == (int)(ExamType.Final));
        }
        void PracticalExam()
        {

            q = examQuestions[QuestionCounter];
            questionBody.Text = q.QuestBody;
            questionMarks.Text = "Marks: " + q.Marks.ToString();
            List<string> QuestionChoices = new List<string>();
            foreach (var item in examChoices)
            {
                if (item.QuestID == q.QuestID && item.QuestType == q.QuestType)
                    QuestionChoices.Add(item.QuestChoices);
            }
            questionChoices.DataSource = QuestionChoices;
            if (QuestionCounter < examQuestions.Count - 1)
            {
                QuestionCounter++;

                q2 = examQuestions[QuestionCounter];
                question2Body.Text = q2.QuestBody;
                question2Marks.Text = "Marks: " + q2.Marks.ToString();
                List<string> Question2Choices = new List<string>();
                foreach (var item in examChoices)
                {
                    if (item.QuestID == q2.QuestID && item.QuestType == q2.QuestType)
                        Question2Choices.Add(item.QuestChoices);
                }
                questionChoices2.DataSource = Question2Choices;
            }
            else
            {
                question2Body.Visible = false;
                question2Marks.Visible = false;
                questionChoices2.Visible = false;

            }

            if (QuestionCounter == examQuestions.Count - 1)
                next.Text = "Finish";

        }

        private void next_Click(object sender, EventArgs e)
        {
            if (QuestionCounter < examQuestions.Count - 1)
            {
                answers.Add(new StudentAnswer() { QuestID = q.QuestID, QuestType = q.QuestType, StudAnswer = questionChoices.SelectedValue.ToString() });
                answers.Add(new StudentAnswer() { QuestID = q2.QuestID, QuestType = q2.QuestType, StudAnswer = questionChoices2.SelectedValue.ToString() });
                QuestionCounter++;
                PracticalExam();
            }
            else
            {
                answers.Add(new StudentAnswer() { QuestID = q.QuestID, QuestType = q.QuestType, StudAnswer = questionChoices.SelectedValue.ToString() });
                if (!q2.QuestBody.Equals(""))
                    answers.Add(new StudentAnswer() { QuestID = q2.QuestID, QuestType = q2.QuestType, StudAnswer = questionChoices2.SelectedValue.ToString() });
                int studentID = StudentManager.getInstance().StudentID;
                foreach (var item in answers)
                {
                    if (manager.TakeAnswers(studentID, item.StudAnswer, item.QuestID, item.QuestType) > 0)
                    {
                        Trace.WriteLine("done");
                    }
                    else
                        Trace.WriteLine("Not");

                }
                if (manager.ExamCorrection(studentID) > 0)
                {
                    Trace.WriteLine("a7la exam wala eh !!! <3");
                }
                else
                    Trace.WriteLine("la la la");
                this.Hide();
                Results rs = new Results();
                rs.FormClosed += (e, sender) => this.Close();
                rs.Show();

            }

        }
    }
}
