# Right To Go

This is a website for learning more about international law, personal rights on a more global scale. Perfect for students who are engaged in studies connected to International relationships, European Law or even for people who want to be more knowledgeable as when it comes to personal rights, human rights, etc.

------
When you register you are given the option to choose to be a normal user, a student or a teacher. 

All users have:
 * Email(req)
 * Username(req) - between 3 and 20 symbols, only a-Z & 0-9
 * Password(req) - between 5 and 20 symbols, must have a-Z & 0-9 (symbols,caps - opt)
 * Avatar
 * FirstName - between 2 and 20 symbols
 * LastName - between 2 and 20 symbols
 * University(req)
 * Likes

Normal users can review articles, search through all articles, basically they have "read permissions". Can also like works.

Students have:
 * TestsTaken
 * Grades
 * Faculty - between 2 and 20 symbols
 * Specialty - between 2 and 20 symbols
 * *Works*

Students can do everything a normal user can do, but they can also take part in Tests to which they are authorised. *They can also add personal works.*

Teachers have:
 * Videos - not implemented yet
 * TestsCreated - not implemented yet
 * FieldOfStudy - between 2 and 20 symbols
 * *Articles*

Teachers can do everything a normal user can do, but they can also add tests and authorize students to participate. *They can also add articles.*

------

Students can add **works** on their profile. Works have:

 * Title(req) - between 2 and 20 symbols
 * Topic(req)
 * Content(req) - MinLength(2)
 * CreatedOn(req)
 * CreatedBy(req)

 * Likes

Teachers can add **articles**, which are publicly visible. Articles have:

 * Title(req) - between 2 and 20 symbols
 * Topic(req)
 * Content(req) - MinLength(2)
 * CreatedOn(req)
 * CreatedBy(req)
 
 * RelatedVideos  - not implemented yet
 * RelatedArticles
 
------
Teachers can create **Tests** and **add Students** to participate. Tests have:
**Not implemented yet**
 * Topic(req)
 * CreatedBy(req)
 * CreatedOn(req)
 * StudentsAllowed
 * RelatedQuestions

Students can take tests and receive **grades**. Grades have:
**Not implemented yet**
 * Value(req) - between 0 and 100. (percentage based on correct answers/questions)
 * RelatedTest(req)
 * RelatedStudent(req)
 * RelatedExaminer(req) - the creator of the Test

------

##### Administrator Area

Administrators can:

 * Add/Edit/Remove Topics
 * Add/Edit/Remove Articles
 * Add/Edit/Remove Universities
 * Add/Edit/Remove Works
 * Add/Edit/Remove Tests
 * Add/Edit/Remove Videos - not implemented yet
 * Edit/Remove Users - not implemented yet

## Data

### Models

#### Roles

* administrator

#### User

* Email(req)
* Username(req)
* Password(req)
* Avatar
* FirstName
* LastName
* University

* Teacher related
  * FieldOfStudy ??
  * Videos
  * TestsCreated
  * Articles
* Student related
  * TestsTaken
  * Grades
  * Faculty
  * Specialty
  * Works

#### TeacherAccessTokens - not implemented
 * Value
 * IsTaken

#### Topic

* Name
* RelatedArticles

#### Article
 * Title
 * Topic
 * Content
 * CreatedOn
 * CreatedBy
 
 * RelatedVideos - not implemented yet
 * RelatedArticles

#### Works
* Title
 * Topic
 * Content
 * CreatedOn
 * CreatedBy
 
 * Likes

#### Like
 * Value (-1, 0 or 1) -  Enumeration
 * User
 * RelatedWork

#### Video - not implemented yet

* YoutubeURL
* Title
* CreatedBy
* CreatedOn
* RelatedArticles

#### Test - not implemented yet (only Admin)

* Name
* CreatedBy
* CreatedOn
* StudentsAllowed
* RelatedQuestions

#### Question - not implemented yet
* Task
* Answers
* Explanation

#### Answer - not implemented yet
 * Value
 * IsCorrect

#### Grade - not implemented yet

 * Value
 * RelatedTest
 * RelatedStudent
 * RelatedExaminer

