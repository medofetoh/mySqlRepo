--1
CREATE PROCEDURE [dbo].[CheckPassword]
    @useremail VARCHAR(20),
    @password varchar(20)
AS
BEGIN
SET NOCOUNT ON
IF EXISTS(SELECT * FROM Students s WHERE StudEmail = @useremail AND StudPassword = @password)
    SELECT StudID from Students
ELSE
    SELECT 'false' AS UserExists
END
------------------------------------------------------------
--2 create getExamQuestions table 
CREATE proc [dbo].[getExamQuestions] @ExamID int
as
select  Q.QuestID, Q.QuestType ,Q.QuestBody,Q.Marks
	from Participaton P 
	inner join Question Q on Q.QuestID = P.QuestID and Q.QuestType = P.QuestType
	where P.ExamID=@ExamID order by Q.QuestID
----------------------------------------------------------------
--3
create proc [dbo].[getStudentGrade] @studentID int
as
	select S.StudID, S.StudFName + ' ' + S.StudLName as 'Full Name', C.CourseName , SC.CourseMarks
	from Students S
	inner join StudCourse SC 
	on S.StudID= SC.StudID
	inner join Course C
	on SC.CourseID = C.CourseID
	where S.StudID= @studentID 
------------------------------------------------------------------
--4
create proc [dbo].[getTopics] @CourseID varchar(5)
as
	select T.TopName
	from Topic T
	inner join Course C on C.CourseID= T.CourseID
    where C.CourseID= @CourseID
----------------------------------------------------------------
--5
create proc [dbo].[Sp_addChoicesMCQ] @questID int , @choice1 varchar(100),@choice2 varchar(100),@choice3 varchar(100),@choice4 varchar(100) as
begin
insert into Choices values(@questID ,'MCQ' ,@choice1),(@questID ,'MCQ',@choice2),
(@questID ,'MCQ',@choice3),(@questID ,'MCQ',@choice4)
end
----------------------------------------------------------------
--6
CREATE proc [dbo].[Sp_addchoicesTorF] @questID int as
begin
insert into Choices values (@questID ,'TorF' ,'True'),(@questID ,'TorF','False')
end
--------------------------------------------------------------
--7

create proc [dbo].[Sp_addNewCourse] @newCourseID varchar(5),@newCourseName varchar(20) , @newCourseMarks int,
@newCoursePassPercentage decimal(18, 0), @newMaxNoOfStuds int ,@newInstID int as
begin
insert into Course values
(@newCourseID,@newCourseName,@newCourseMarks,@newCoursePassPercentage,@newMaxNoOfStuds,@newInstID)
end
-----------------------------------------------------------------
--8

CREATE proc [dbo].[Sp_addNewTopic] @newTopicID int  , @courseID varchar(5),@topicName varchar(20) as
begin 
insert into Topic 
values (@newTopicID ,@courseID,@topicName)
end

----------------------------------------------------------------

--9
CREATE proc [dbo].[Sp_courseFullMark] @ExamID int 
as
select  sum(Q.Marks) as Marks
	from Participaton P 
	inner join Question Q on Q.QuestID = P.QuestID and Q.QuestType = P.QuestType
	where P.ExamID=@ExamID 
---------------------------------------------------------------

--10
CREATE proc [dbo].[Sp_EnrollCourse]  @courseID varchar(5),@studID int
  as
  begin
  declare @maxNom int
  set @maxNom=
  (select c.MaxNoOfStuds
  from Course c
  where c.CourseID=@courseID)
  declare @count int
  set @count =(
  select COUNT(s.StudID)
  from StudCourse s 
  where s.CourseID=@courseID)
   if @maxNom < @count
   select 'reached max nom of students' as ResMessage 
   else 
   insert into StudCourse (StudID,CourseID)values(@studID ,@courseID)
  end

  ------------------------------------------------

  --11
  create proc [dbo].[Sp_ExamCorrection] @StudID int ,@ExamID int
as 
begin
UPDATE Participaton  
SET StudMarks = Q.Marks  
FROM Participaton P  
INNER JOIN Question Q ON P.QuestID = Q.QuestID and P.QuestType =Q.QuestType  
WHERE P.StudAns = Q.CorrectAns and P.StudID =@StudID and P.ExamID=@ExamID 
end
--------------------------------------------------
--12
CREATE proc [dbo].[Sp_examinedStudents] @ExamID int as
begin
select distinct s.StudFName +' '+s.StudLName as 'Student Full Name'
from Participaton P inner join Students s
on P.StudID =s.StudID
where P.ExamID=@ExamID
end
----------------------------------------------------

--13
create proc [dbo].[Sp_failed] as
  begin
  delete from Students
  where StudTotalGrade='F'
  end 
  -------------------------------------------------

  --14

  create proc [dbo].[Sp_GetChoices] @QuestID int, @QuestType varchar(5)
as
begin
select Q.QuestBody, 
stuff ((select ' - ' + Ch.QuestChoices
		from Question Q inner join Choices Ch
		on Q.QuestID = Ch.QuestID and Q.QuestType = Ch.QuestType
		where Ch.QuestID = @QuestID and Ch.QuestType = @QuestType
		FOR XML PATH('')), 1, 1, '') [Choices]
from Question Q inner join Choices Ch
on Q.QuestID = Ch.QuestID and Q.QuestType = Ch.QuestType
where Ch.QuestID = @QuestID and Ch.QuestType = @QuestType
GROUP BY Q.QuestBody
ORDER BY 1
end

------------------------------------------------------

--15

create proc [dbo].[Sp_getCourseDetails] @courseID varchar(5) as
begin
select c.CourseName ,c.CourseMarks ,i.InstFName +' '+i.InstLName as 'instructor' 
from Course c inner join Instructor i
on c.InstID=i.InstID
where c.CourseID=@courseID
end

------------------------------------------------------

--16

create proc [dbo].[Sp_getDetails]  (@col varchar(20), @t varchar(50))
as
execute('select '+@col+' from '+@t)
GO

-----------------------------------------------------

--17

CREATE proc [dbo].[Sp_GetEnrolledCourses] @studID int as
begin 
select c.CourseName as 'Enrolled Courses'
from StudCourse sc inner join Course c
on sc.CourseID=c.CourseID
where sc.StudID =@studID
end

------------------------------------------------------

--18

CREATE proc [dbo].[SP_getExamChoices] @CourseID varchar(5)
as 
select distinct Q.QuestID, Q.QuestType ,Ch.QuestChoices
	from Participaton P 
	inner join Question Q on Q.QuestID = P.QuestID and Q.QuestType = P.QuestType
	inner join Choices Ch on Ch.QuestID = Q.QuestID and Ch.QuestType = Q.QuestType
	where Q.CourseID=@CourseID order by Q.QuestID

--------------------------------------------------------

--19

CREATE proc [dbo].[Sp_GetExamDateAndTime] @examID int as
begin
select distinct E.ExamDatetime as 'Exam Date and Time' , CONCAT( E.ExamDuration , ' Hour') as 'Duration'
from Participaton P inner join Exam E
on P.ExamID=E.ExamID
where P.ExamID=@examID
end

------------------------------------------------------------

--20

create proc [dbo].[Sp_getExamQuestionsAndStudAnswers] @ExamID int, @StudID int
as
	select Q.QuestBody, P.StudAns
	from Participaton P inner join Question Q on P.QuestID = Q.QuestID and P.QuestType = Q.QuestType
	where P.ExamID = @ExamID and P.StudID = @StudID

-------------------------------------------------------------

--30

create procedure [dbo].[SP_GetInstructorCourseData] @insID int
as 
begin
	 select C.CourseName,count(*) AS NumberOfStudnt 
	 from Instructor I
	 inner join Course C
	 on I.InstID = C.InstID  
	 inner join StudCourse SC
	 on C.CourseID = SC.CourseID where I.InstID=@insID
	 group by C.CourseName

----------------------------------------------------------

--31

create proc [dbo].[Sp_GetInstructorCourses] @insID int
as
begin
declare c1 cursor
for select distinct I.InstFName + ' ' + I.InstLName as 'Instructor Name', C.CourseName
from Instructor I inner join Course C
on I.InstID = C.InstID
where I.InstID = @insID
for read only
declare @Iname varchar(30),@Cname varchar(20),@AllCourses varchar(200)
open c1
fetch c1 into @Iname,@Cname
while @@FETCH_STATUS=0
	begin
	if @AllCourses is null
		begin
		set @AllCourses = @Cname
		fetch c1 into @Iname,@Cname
		end
	else
		begin
		set @AllCourses = CONCAT(@AllCourses,',',@Cname)
		fetch c1 into @Iname,@Cname
		end
	end
select @Iname as 'Instructor Name',@AllCourses as 'Course Names'
close c1
deallocate c1
end
-----------------------------------------------------------------
--32
create proc [dbo].[Sp_GetNumOfStudents] @insID int
as
begin
select I.InstFName + ' ' + I.InstLName as 'Instructor Name', COUNT(S.StudID) as 'Number of Students'
from Instructor I inner join Department D
on I.DeptID = D.DeptID
inner join Students S
on D.DeptID = S.DeptID
where I.InstID = @insID
group by I.InstFName, I.InstLName
end

---------------------------------------------------------------
--33

create procedure [dbo].[Sp_GetStudentData]
as
begin
	select s.* 
	from Students S
	inner join Department D
	on  D.DeptID = S.DeptID
end

------------------------------------------------------------
--34

CREATE proc [dbo].[Sp_GetStudentInformation] @departnum varchar(10)
  as
  begin
      select s.* from Students s
      inner join Department d
      on  d.DeptID=s.DeptID
      where d.DeptID=@departnum
  end

----------------------------------------------------------

--35

create proc [dbo].[Sp_GetStudentMarksPerCourse] @studID int as
begin
select c.CourseName as 'Enrolled Courses' , sc.CourseMarks as 'Student Mark'
from StudCourse sc inner join Course c
on sc.CourseID=c.CourseID
where sc.StudID =@studID
end

---------------------------------------------------------

--36

create proc [dbo].[Sp_GetStudentTotalGrade] @StudID int
as
begin
select S.StudFName + ' ' + S.StudLName, S.StudTotalGrade
from Students S
where S.StudID = @StudID
end

----------------------------------------------------

--37

create proc [dbo].[Sp_getUserInfo] @ID int as
begin
IF EXISTS(SELECT * FROM Instructor WHERE InstID = @ID)
begin
SELECT * FROM Instructor WHERE InstID = @ID
end
else if EXISTS(SELECT * FROM Students WHERE StudID = @ID)
begin
SELECT * FROM Students WHERE StudID = @ID
end
else
select 'ID is not Found' as 'STATUS'
end

-----------------------------------------------------

--38

CREATE proc [dbo].[Sp_InsGenerateExam] @CourseID varchar(5),@ExamDate datetime ,@examType varchar(20)
as
begin
declare @examId int
set @examId =(select MAX(e.ExamID)+1 from Exam e)

declare @examDuration int 

declare @nomOfQues int
if @examType ='Final'
begin 
set @nomOfQues=10
set @examDuration=2
end
else 
begin
set @nomOfQues=6
set @examDuration=1
end
--add generated exam
insert into Exam (ExamID,ExamNoOfQuest,ExamDatetime,ExamDuration,ExamType)
Values (@examId,@nomOfQues,@ExamDate,@examDuration,@examType)

declare @partID int
set @partID=(select isnull(MAX(P.PartID),0) from Participaton P)
set @partID+=1 

insert into Participaton(QuestID,PartID,ExamID,QuestType)
select top (@nomOfQues/2) Q.QuestID,@partID,@examId ,'TorF'
from Question Q
where @CourseID =Q.CourseID and Q.QuestType='TorF'
order by NEWID()

insert into Participaton(QuestID,PartID,ExamID,QuestType)
select top (@nomOfQues/2) Q.QuestID, @partID,@examId ,'MCQ'
from Question Q
where @CourseID =Q.CourseID and Q.QuestType='MCQ'
order by NEWID()

insert into ExamQuest(ExamID , QuestID ,QuestType)
select ExamID,QuestID,QuestType 
from Participaton
where ExamID=@examId

End
-----------------------------------------------------------
--39

CREATE proc [dbo].[Sp_instCheckPassword] @instEmail varchar(30), @password varchar(20) as
IF EXISTS(SELECT * FROM Instructor WHERE InstEmail = @instEmail AND InstPassword = @password)
SELECT 1 AS UserExists
ELSE
SELECT -1 AS UserExists

-------------------------------------------------------

--40

create proc [dbo].[Sp_instOnlyAddQuestion] @quesID int ,@quesType varchar(20),@instID int,
@questBody varchar(200) ,@marks int , @courseID varchar(5),@correctAns varchar(100) as
begin
IF EXISTS(SELECT * FROM Instructor WHERE InstID = @InstID)
begin
insert into Question 
values (@quesID,@quesType,@questBody,@marks,@courseID,@correctAns)
end
else
select 'Instructor only can Add question' as 'STATUS'
end

---------------------------------------------------------------

--41

CREATE proc [dbo].[Sp_instOnlyUpdateExam] @examID int ,@instID int , @ExamNoOfQuest int ,@ExamType varchar(20) as
begin
IF EXISTS(SELECT * FROM Instructor WHERE InstID = @InstID)
begin
update Exam 
set ExamNoOfQuest=@ExamNoOfQuest , ExamType=@ExamType
where ExamID=@examID
end
else
select 'Instructor only can edit Exam' as 'STATUS'
end

----------------------------------------------------------------

--42

CREATE proc [dbo].[SP_SelectCoursesExams]
as
select distinct C.CourseName,C.CourseID
from Participaton P 
inner join Question Q on P.QuestID=Q.QuestID 
and P.QuestType=Q.QuestType
inner join Course C
on Q.CourseID=C.CourseID

---------------------------------------------------------------

--43

CREATE proc [dbo].[SP_SelectCoursesSpecificExam] @CourseID varchar(5)
as
select distinct P.ExamID,E.ExamDatetime
from Participaton P 
inner join Question Q on P.QuestID=Q.QuestID 
and P.QuestType=Q.QuestType
inner join Course C
on Q.CourseID=C.CourseID
inner join Exam E on P.ExamID=E.ExamID
where C.CourseID=@CourseID and p.StudID is null

--------------------------------------------------------------------

--44

create Proc [dbo].[SP_SelectDepartments]
as
Select  DeptID,DeptName
from Department

------------------------------------------------------------------------

--45

CREATE Proc [dbo].[SP_SelectInstructors]
as
Select  InstID as InstructID,InstFName,InstLName 
from Instructor

------------------------------------------------------------

--46

CREATE proc [dbo].[Sp_ShowModelAnswers] @ExamID int as
begin
select distinct Q.QuestBody, Q.QuestType ,Q.CorrectAns
from Participaton P
inner join Question Q on Q.QuestID = P.QuestID and Q.QuestType =P.QuestType
inner join Choices C on C.QuestID = Q.QuestID and C.QuestType = Q.QuestType
inner join Course cor on cor.CourseID=Q.CourseID
where P.ExamID = @ExamID 
end

----------------------------------------------------

--47

create proc [dbo].[Sp_ShowStudentAnswers] @ExamID int, @StudID int as
begin 
select distinct Q.QuestBody, P.StudAns
from Participaton P
inner join Question Q on Q.QuestID = P.QuestID and Q.QuestType =P.QuestType
where P.ExamID=@ExamID and P.StudID=@StudID
end

-------------------------------------------------------

--48

CREATE proc [dbo].[Sp_StExamRetrival] @ExamID int , @ExamDateTime datetime
as
begin
select Q.QuestBody,Q.QuestType,Q.Marks,cor.CourseName ,E.ExamDatetime ,E.ExamNoOfQuest ,E.ExamType ,E.ExamDuration
from Participaton P
inner join Question Q on Q.QuestID = P.QuestID and Q.QuestType =P.QuestType
inner join Choices C on C.QuestID = Q.QuestID and C.QuestType = Q.QuestType
inner join Course cor on cor.CourseID=Q.CourseID
inner join Exam E on E.ExamID=P.ExamID
where E.ExamID = @ExamID and E.ExamDatetime=@ExamDateTime
end

---------------------------------------------------------

--49

create PROCEDURE [dbo].[Sp_StudentCheckPassword]
@useremail VARCHAR(30),
@password varchar(20)
AS
BEGIN
IF EXISTS(SELECT * FROM Students WHERE StudEmail = @useremail AND StudPassword = @password)
begin (
SELECT s.StudID
from Students s
where s.StudEmail=@useremail and s.StudPassword=@password)
end
ELSE
SELECT -1 AS UserExists
END

-------------------------------------------------------------

--50

CREATE proc [dbo].[Sp_StudentDidntExamined] @courseID varchar(5) as 
begin
select  s.StudFName + ' '+ s.StudLName as 'Student Full name'
from Students s
where StudID in (
select sc.StudID 
from StudCourse sc inner join Students s
on sc.StudID=s.StudID
where CourseID=@courseID except(
select StudID
from Participaton P))
end

-------------------------------------------------------------------

--51

CREATE proc [dbo].[Sp_sumOfMarksPerCourse] @CourseID varchar(5) ,@ExamID int ,@StudID int
as
begin
declare @marksOfCourse int
set @marksOfCourse = (select sum (isnull(P.StudMarks,0))
from Participaton P inner join Question Q
on P.QuestID=Q.QuestID and P.QuestType =Q.QuestType
inner join Course C
on Q.CourseID =C.CourseID
where C.CourseID =@CourseID and P.ExamID=@ExamID and P.StudID=@StudID
)
update StudCourse
set CourseMarks = @marksOfCourse
where CourseID=@CourseID and StudID=@StudID

select sc.CourseMarks
from StudCourse sc
where sc.StudID=@StudID and sc.CourseID=@CourseID
end

-------------------------------------------------------

--52

CREATE proc [dbo].[Sp_TakeAnswers] @ExamID int,@CourseID varchar(5) ,@StudID int, @StudAnswer varchar(100),@quesID int , @quesType varchar(20)
 as
begin
update Participaton 
Set StudID=@StudID , StudAns=@StudAnswer
where ExamID =@ExamID and QuestID=@quesID and QuestType=@quesType
insert into StudCourse 
(StudID,CourseID) values (@StudID,@CourseID)
end

--------------------------------------------------------------

--53

create proc [dbo].[Sp_totalGrade] @StuID int as
begin

declare @totalGradePerc decimal
set @totalGradePerc=
(
select sum(ISNULL(SC.CourseMarks,0))
from StudCourse SC
where SC.StudID=@StuID
)/
(
select sum(C.CourseMarks)
from Course C inner join StudCourse SC
on C.CourseID = SC.CourseID and SC.StudID = @StuID
)
declare @totalGrade varchar(1)
set @totalGrade =
(
    CASE
        WHEN @totalGradePerc between 100 and 90 THEN 'A'
        WHEN @totalGradePerc between 89 and  80 THEN 'B'
        WHEN @totalGradePerc between 70 and 79 THEN 'C'
		WHEN @totalGradePerc between 69 and 60 THEN 'D'
        WHEN @totalGradePerc between 0 and 59 THEN 'F'
    END )
	


update Students
set StudTotalGrade = @totalGrade
where StudID=@StuID

end

----------------------------------------------------

--54

create proc [dbo].[Sp_updateCourseInstructor] @courseID varchar(5), @newInstID int as
begin
update Course
set InstID=@newInstID
where CourseID=@courseID
end

-----------------------------------------------------

--55

create proc [dbo].[Sp_updateInstructorData] @InstID int ,@newMail varchar(30) , @newPassword varchar(20) as
begin
IF EXISTS(SELECT * FROM Instructor WHERE InstID = @InstID)
begin 
update Instructor
set InstEmail =@newMail , InstPassword=@newPassword
where InstID=@InstID
end
else
select 'Instructor Not Found' as 'STATUS'
end

----------------------------------------------------------

--56

CREATE proc [dbo].[Sp_updateStudentData] @StudID int ,@newMail varchar(30) , @newPassword varchar(20) as
begin
IF EXISTS(SELECT * FROM Students WHERE StudID= @StudID)
begin 
update Students 
set StudEmail =@newMail , StudPassword=@newPassword
where StudID=@StudID
end
else
select 'Student Not Found' as 'STATUS'
end

--------------------------------------------------------
--57

CREATE proc [dbo].[Sp_updateStudentMarks] @StudID int , @courseID varchar(5) ,@newMark int as 
begin
declare @courseMarks int
set @courseMarks =(select CourseMarks from Course where CourseID=@courseID)
if @newMark <= @courseMarks
begin
update StudCourse 
set CourseMarks =@newMark
where StudID=@StudID and CourseID=@courseID
end 
else 
select 'Mark is not approved' as 'STATUS'
end

-----------------------------------------------------
--58

create proc [dbo].[Sp_updateStudentTotalGrade] @StudID int , @newGrade varchar(1) as
begin
update Students 
set StudTotalGrade =@newGrade
where StudID=@StudID
end

--------------------------------------------------
--59
create proc [dbo].[Sp_withdraw] @studID int as
  begin 
  delete from Students 
  where StudID=@studID
  end
