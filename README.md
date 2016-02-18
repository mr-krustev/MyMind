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
 * University - between 2 and 20 symbols

Normal users can review articles, search through all articles, basically they have "read permissions". 

Students have:
 * TestsTaken
 * Grades
 * Faculty - between 2 and 20 symbols
 * Specialty - between 2 and 20 symbols
 * *Works*

Students can do everything a normal user can do, but they can also take part in Tests to which they are authorised. *They can also add personal works.*

Teachers have:
 * Videos
 * TestsCreated
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
 * IsPrivate(req) - default false
 * AuthorizedUsers - default only Publisher

 * Likes

Teachers can add **articles**, which are publicly visible. Articles have:

 * Title(req) - between 2 and 20 symbols
 * Topic(req)
 * Content(req) - MinLength(2)
 * CreatedOn(req)
 * CreatedBy(req)
 * IsPrivate(req) - default false
 * AuthorizedUsers - default only Publisher

 * RelatedVideos
 * RelatedArticles
 
------
Teachers can create **Tests** and **add Students** to participate. Tests have:

 * Topic(req)
 * CreatedBy(req)
 * CreatedOn(req)
 * StudentsAllowed
 * RelatedQuestions

Students can take tests and receive **grades**. Grades have:

 * Value(req) - between 0 and 100. (percentage based on correct answers/questions)
 * RelatedTest(req)
 * RelatedStudent(req)
 * RelatedExaminer(req) - the creator of the Test

------



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


#### Teacher extends User
  * FieldOfStudy ??
  * Videos
  * TestsCreated
  * Articles

#### Student extends User
  * TestsTaken
  * Grades
  * Faculty
  * Specialty
  * Works

#### TeacherAccessTokens
 * Value
 * IsTaken

#### Topic

* Name
* RelatedArticles

#### Publication
 * Title
 * Topic
 * Content
 * CreatedOn
 * CreatedBy
 * IsPrivate
 * AuthorizedUsers

#### Article extends Publication

* RelatedVideos
* RelatedArticles

#### Works extends Publication
 * Likes

#### Video

* File / Path to File
* Name
* UploadedBy
* UploadedOn
* RelatedArticles

#### Test

* Name
* CreatedBy
* CreatedOn
* StudentsAllowed
* RelatedQuestions

#### Question
* Task
* Answers
* Explanation

#### Answer
 * Value
 * IsCorrect

#### Grade

 * Value
 * RelatedTest
 * RelatedStudent
 * RelatedExaminer

### Services

* UsersServices
* ArticlesServices
* TestsServices
* VideosServices

## Web

### Routes

### Controllers

...

