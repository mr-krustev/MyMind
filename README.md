# Right To Go

## Data

### Models

#### Roles

* admin
* teacher
* student

#### User

* Email
* Username
* Password
* Avatar
* **Teacher related**
  * Videos
  * TestsCreated
* **Student Related**
  * TestsTaken
  * Grades
* 

#### Video

* File / Path to File
* Name
* UploadedBy
* UploadedOn
* RelatedArticles

#### Topic

* Name
* Articles

#### Article

* Name
* Topic
* CreatedBy
* CreatedOn
* Videos
* RelatedArticles
* 

#### Test

* Name
* CreatedBy
* CreatedOn
* StudentsAllowed
* 

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

