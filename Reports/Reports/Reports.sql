-- Report that returns the students information according to Department No parameter. (DONE)
 
create procedure Sp_GetStudentData
as
begin
	select s.* 
	from Students S
	inner join Department D
	on  D.DeptID = S.DeptID
end
 
 
Sp_GetStudentData


-- Report that takes course ID and returns its topics  (DONE)

create proc getTopics @CourseID varchar(5)
as
	select T.TopName
	from Topic T
	inner join Course C on C.CourseID= T.CourseID
    where C.CourseID= @CourseID


getTopics 'CS102'

-- Report that takes exam number and returns Questions in it (Done)

alter proc getExamQuestions @ExamID int
as
	select Q.QuestBody, Ch.QuestChoices
	from Participaton P inner join Question Q
	on Q.QuestID = P.QuestID and Q.QuestType = P.QuestType
	inner join Choices Ch on Ch.QuestID = Q.QuestID and Ch.QuestType = Q.QuestType
	where P.ExamID = @ExamID

getExamQuestions 3

 -- Report that takes the student ID and returns the grades of the student in all courses.

create proc getStudentGrade @studentID int
as
	select S.StudID, S.StudFName + ' ' + S.StudLName as 'Full Name', C.CourseName , SC.CourseMarks
	from Students S
	inner join StudCourse SC 
	on S.StudID= SC.StudID
	inner join Course C
	on SC.CourseID = C.CourseID
	where S.StudID= @studentID 

getStudentGrade 3

-- Report that takes the instructor ID and returns the name of the courses that he teaches and the number of student per course.

create procedure SP_GetInstructorCourseData @insID int
as 
begin
	 select C.CourseName,count(*) AS NumberOfStudnt 
	 from Instructor I
	 inner join Course C
	 on I.InstID = C.InstID  
	 inner join StudCourse SC
	 on C.CourseID = SC.CourseID where I.InstID=@insID
	 group by C.CourseName
end

SP_GetInstructorCourseData 1011

--•	Report that takes exam number and the student ID 
--then returns the Questions in this exam with the student answers.

create proc Sp_getExamQuestionsAndStudAnswers @ExamID int, @StudID int
as
	select Q.QuestBody, P.StudAns
	from Participaton P inner join Question Q on P.QuestID = Q.QuestID and P.QuestType = Q.QuestType
	where P.ExamID = @ExamID and P.StudID = @StudID

Sp_getExamQuestionsAndStudAnswers 3, 3
